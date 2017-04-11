using KsheeraSagara.Model;
using KsheeraSagara.Shared;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KsheeraSagara.ViewModels
{
    public class MilkPurchasePageViewModel : BindableBase,INavigatedAware
    {
        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;

        public MilkPurchasePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;


            SharedValues._LstMembers = new List<Member>();

            SharedValues._LstMilkPurchase = new List<MilkPurchaseModel>();

            ToDaysDate = DateTime.Now;

            if (ToDaysDate.ToString("tt") == "AM")
            {
                Session = "Morning \u25BC";
                _sessionModel = SessionModel.Morning;
            }
            else
            {
                Session = "Evening \u25BC";
                _sessionModel = SessionModel.Evening;
            }

            MilkType = "Cow Milk \u25BC";
        }




        private DateTime _toDaysDate;
        private string _session;
        private Member _dairyMember;
        private string _cardNumber;
        private string _memberName;
        private string _milkType;
        private double _fat;
        private double _litre;

        private SessionModel _sessionModel;
        private double _totalLitre;
        private double _totalFat;
        private int _noOfMembers;
        private double _milkPrice=24.5;

        public DateTime ToDaysDate { get => _toDaysDate; set =>SetProperty(ref _toDaysDate , value); }
        public string Session { get => _session; set =>SetProperty(ref _session , value); }




        public DelegateCommand SessionCommand => new DelegateCommand(SessionCommandAsync);
        public DelegateCommand MilkTypeCommand => new DelegateCommand(MilkTypeCommandAsync);
        public DelegateCommand SaveCommand => new DelegateCommand(SaveCommandAsync);

        

        public Member DairyMember { get => _dairyMember; set =>SetProperty(ref _dairyMember, value); }
        public string CardNumber { get => _cardNumber; set{ SetProperty(ref _cardNumber, value); GetMemberFromCardNumber(); } }

        public string MemberName { get => _memberName; set => SetProperty(ref _memberName, value); }
        public string MilkType { get => _milkType; set =>SetProperty(ref _milkType , value); }
        public double Fat { get => _fat; set =>SetProperty(ref _fat , value); }
        public double Litre { get => _litre; set =>SetProperty(ref _litre , value); }

        private async void SessionCommandAsync()
        {
            var res= await _pageDialogService.DisplayActionSheetAsync("Session:", "Cancel", "", new[]
            {
                "Morning",
                "Evening"
            });

            if (res == "Cancel")
                return;
            Session = res + "\u25BC";
        }

        private async void MilkTypeCommandAsync()
        {
            var res = await _pageDialogService.DisplayActionSheetAsync("Milk Type:", "Cancel", "", new[]
            {
                "Cow Milk",
                "Buffalo Milk"
            });

            if (res == "Cancel")
                return;
            MilkType = res + "\u25BC";
        }

        private async void SaveCommandAsync()
        {
            if (DairyMember == null)
            {
                await _pageDialogService.DisplayAlertAsync("Info", "Invalid Card Number", "Ok");
                return;
            }

            if (Fat <= 0)
            {
                await _pageDialogService.DisplayAlertAsync("Info", "Invalid Fat", "Ok");
                return;
            }
            if (Litre <= 0)
            {
                await _pageDialogService.DisplayAlertAsync("Info", "Invalid Litre", "Ok");
                return;
            }

            MilkPurchaseModel mp = new MilkPurchaseModel
            {
                CardNumber = DairyMember.CardNumber,
                Litre=Litre,
                Fat=Fat,
                Price=Litre*_milkPrice,
                Session=_sessionModel,
                Date=ToDaysDate
            };

            _totalFat += Fat;
            _totalLitre += Litre;
            _noOfMembers++;

            var avgFat = _totalFat / _noOfMembers;
            var totalPrice = _totalLitre * _milkPrice;

            SharedValues._LstMilkPurchase.Add(mp);

            await _pageDialogService.DisplayAlertAsync("Info",
                $"Ltrs: {_totalLitre}\r\n\r\nAvgFat: {avgFat}\r\n\r\nAmount: \u20B9 {totalPrice}", 
                "Ok");

            CardNumber = "";
            Fat = 0;
            Litre = 0;

        }


        private async void GetMemberFromCardNumber()
        {
            try
            {
                if (SharedValues._LstMembers.Count == 0)
                    throw new Exception();
                DairyMember = SharedValues._LstMembers.Find(x => x.CardNumber ==int.Parse(CardNumber));
                MemberName = DairyMember.Name;
            }
            catch
            {
                DairyMember = null;
                MemberName = "Invalid CardNumber";
            }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (SharedValues._LstMembers.Count == 0)
            {
                SharedValues._LstMembers = App.MlkDb.GetMembers();
            }
        }
    }
}
