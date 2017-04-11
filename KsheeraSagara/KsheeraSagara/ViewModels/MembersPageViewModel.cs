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

        public MembersPageViewModel(INavigationService navigationService,IPageDialogService pageDialogService)
        {
            _nav = navigationService;
            _pds = pageDialogService;
        }

        private int _cardNumber;
        private string _memberType;
        private string _name;
        private string _kmfUid;
        private long _adharNo;
        private string _phoneNumber;
        private string _caste;
        private string _occupation;
        private string _bankName;
        private string _bankBranchName;
        private string _ifsc;
        private string _accountNo;


        //private string[] _memberType = new[]
        //{
        //    "Share_Holder",
        //    "Non_Share_Holder",
        //    "Other"
        //};

        //private string[] _caste = new[]
        //{
        //    "GM",
        //"SC",
        //"ST",
        //"C1",
        //"2A",
        //"2B",
        //"3A",
        //"3B",
        //"Other"
        //};

        //private string[] _occupation = new[]
        //{
        //    "Farmer",
        //    "Farm Labour",
        //    "Other"
        //};

        public int CardNumber { get => _cardNumber; set =>SetProperty(ref _cardNumber , value); }
        public string MemberType { get => _memberType; set => SetProperty(ref _memberType , value); }
        public string Name { get => _name; set => SetProperty(ref _name , value); }
        public string KmfUid { get => _kmfUid; set => SetProperty(ref _kmfUid , value); }
        public long AdharNo { get => _adharNo; set => SetProperty(ref _adharNo , value); }
        public string PhoneNumber { get => _phoneNumber; set => SetProperty(ref _phoneNumber , value); }
        public string BankName { get => _bankName; set => SetProperty(ref _bankName , value); }
        public string BankBranchName { get => _bankBranchName; set => SetProperty(ref _bankBranchName , value); }
        public string Ifsc { get => _ifsc; set => SetProperty(ref _ifsc , value); }
        public string AccountNo { get => _accountNo; set => SetProperty(ref _accountNo , value); }



    }
}
