using KsheeraSagara.Model;
using KsheeraSagara.Shared;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KsheeraSagara.ViewModels
{
    public class MembersPageViewModel : BindableBase
    {
        private INavigationService _nav;
        private IPageDialogService _pds;

        public MembersPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _nav = navigationService;
            _pds = pageDialogService;

            MemberType = "Non Share Holder";
            Caste = "GM";
            Occupation = "Farmer";
        }

        private int _cardNumber;
        private string _memberType;
        private string _name;
        private string _kmfUid;
        private string _adharNo;
        private string _phoneNumber;
        private string _caste;
        private string _occupation;
        private string _bankName;
        private string _bankBranchName;
        private string _ifsc;
        private string _accountNo;
        
        public int CardNumber { get => _cardNumber; set => SetProperty(ref _cardNumber, value); }
        public string MemberType { get => _memberType; set => SetProperty(ref _memberType, value); }
        public string Name { get => _name; set => SetProperty(ref _name, value); }
        public string KmfUid { get => _kmfUid; set => SetProperty(ref _kmfUid, value); }
        public string AdharNo { get => _adharNo; set => SetProperty(ref _adharNo, value); }
        public string PhoneNumber { get => _phoneNumber; set => SetProperty(ref _phoneNumber, value); }
        public string Caste { get => _caste; set =>SetProperty(ref _caste , value); }
        public string Occupation { get => _occupation; set =>SetProperty(ref _occupation , value); }
        public string BankName { get => _bankName; set => SetProperty(ref _bankName, value); }
        public string BankBranchName { get => _bankBranchName; set => SetProperty(ref _bankBranchName, value); }
        public string Ifsc { get => _ifsc; set => SetProperty(ref _ifsc, value); }
        public string AccountNo { get => _accountNo; set => SetProperty(ref _accountNo, value); }


        public DelegateCommand MemberTypeSelectCommand => new DelegateCommand(MemberTypeSelectCmdAsync);
        public DelegateCommand CasteSelectCommand => new DelegateCommand(CasteSelectCmdAsync);
        public DelegateCommand OccupationSelectCommand => new DelegateCommand(OccupationSelectCmdAsync);
        public DelegateCommand BackCommand => new DelegateCommand(BackCmdAsync);
        public DelegateCommand SaveCommand => new DelegateCommand(SaveCmdAsync);
        

        private async void MemberTypeSelectCmdAsync()
        {
            var res = await _pds.DisplayActionSheetAsync("Member Type:", "Cancel","", new[]
            {
                "Share Holder",
                "Non Share Holder",
                "Other"
            });
            if (res.Equals("Cancel"))
                return;
            MemberType = res;
        }

        private async void CasteSelectCmdAsync()
        {
            var res = await _pds.DisplayActionSheetAsync("Member Type:", "Cancel", "", new[]
            {
                            "GM",
        "SC",
        "ST",
        "C1",
        "2A",
        "2B",
        "3A",
        "3B",
        "Other"
            });
            if (res.Equals("Cancel"))
                return;
            Caste = res;
        }

        private async void OccupationSelectCmdAsync()
        {
            var res = await _pds.DisplayActionSheetAsync("Member Type:", "Cancel", "", new[]
            {
                            "Farmer",
            "Farm Labour",
            "Other"
            });
            if (res.Equals("Cancel"))
                return;
            Occupation = res;
        }

        private async void BackCmdAsync()
        {
            await _nav.GoBackAsync();
        }

        private async void SaveCmdAsync()
        {
            if(CardNumber<1)
            {
                await _pds.DisplayAlertAsync("Info","Invalid card number","Ok");
                return;
            }

            if(SharedValues._LstMembers.Exists(x => x.CardNumber == CardNumber))
            {
                await _pds.DisplayAlertAsync("Info", "Card Number already exists", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Name))
            {
                await _pds.DisplayAlertAsync("Info", "Invalid Name", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(KmfUid))
            {
                await _pds.DisplayAlertAsync("Info", "Invalid KmfUid", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(PhoneNumber))
            {
                await _pds.DisplayAlertAsync("Info", "Invalid PhoneNumber", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(BankName))
            {
                await _pds.DisplayAlertAsync("Info", "Invalid BankName", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(BankBranchName))
            {
                await _pds.DisplayAlertAsync("Info", "Invalid BankBranchName", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Ifsc))
            {
                await _pds.DisplayAlertAsync("Info", "Invalid Ifsc", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(AccountNo))
            {
                await _pds.DisplayAlertAsync("Info", "Invalid AccountNo", "Ok");
                return;
            }

            if (AdharNo.ToString().Length<12)
            {
                await _pds.DisplayAlertAsync("Info", "Invalid AdharNo", "Ok");
                return;
            }

            if (SharedValues._LstMembers.Exists(x => x.AdharNo.Equals(AdharNo)))
            {
                await _pds.DisplayAlertAsync("Info", "AdharNo already exists ", "Ok");
                return;
            }

            try
            {
                var member = new Member
                {
                    MemberType=MemberType,
                    CardNumber=CardNumber,
                    AdharNo=AdharNo,
                    Name=Name,
                    KMFUid=KmfUid,
                    PhoneNumber=PhoneNumber,
                    Caste=Caste,
                    Occupation=Occupation,
                    BankName=BankName,
                    BankBranchName=BankBranchName,
                    IFSC=Ifsc,
                    AccountNumber=AccountNo,
                };
                //App.MlkDb.AddMember(member);
                SharedValues._LstMembers.Add(member);

                await _pds.DisplayAlertAsync("Info", "New user successfully registered", "Ok");

                MemberType = "Non Share Holder";
                CardNumber = 0;
                AdharNo = "";
                Name = "";
                KmfUid = "";
                PhoneNumber = "";
                Caste = "GM";
                Occupation = "Farmer";
                BankBranchName = "";
                BankName = "";
                Ifsc = "";
                AccountNo = "";
            }
            catch(Exception ex)
            {
                await _pds.DisplayAlertAsync("Error", ex.Message, "Ok");
            }
        }
    }
}
