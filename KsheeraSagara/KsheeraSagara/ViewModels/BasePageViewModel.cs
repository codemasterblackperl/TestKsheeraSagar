using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KsheeraSagara.ViewModels
{
    public class BasePageViewModel : BindableBase
    {
        private INavigationService _navigationService;

        private List<string> _lstPages;
        private string _selectedItem;

        private int _currentPage;

        public DelegateCommand MilkPurchaseCommand => new DelegateCommand(MilkPurchaseAsync);
        public DelegateCommand TruckSheetCommand => new DelegateCommand(TruckSheetAsync);
        public DelegateCommand LocalSaleCommand => new DelegateCommand(LocalSaleAsync);
        public DelegateCommand MembersCommand => new DelegateCommand(MembersAsync);

        public List<string> LstPages { get => _lstPages; set =>SetProperty(ref  _lstPages , value); }
        public string SelectedItem { get => _selectedItem; set { SetProperty(ref _selectedItem, value); ChangePageAsync(); } }

        private async void MilkPurchaseAsync()
        {
            if (_currentPage == 0)
                return;
            _currentPage = 0;
            await _navigationService.NavigateAsync("MilkPurchasePage");
        }

        private async void TruckSheetAsync()
        {
            if (_currentPage == 1)
                return;
            _currentPage = 1;
            await _navigationService.NavigateAsync("TruckSheetPage");
        }
        
        private async void LocalSaleAsync()
        {
            if (_currentPage == 2)
                return;
            _currentPage = 2;
            await _navigationService.NavigateAsync("LocalSalePage");
        }
        
        private async void MembersAsync()
        {
            if (_currentPage == 3)
                return;
            _currentPage = 3;
            await _navigationService.NavigateAsync("MembersPage");
        }

        

        public BasePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            LstPages=new List<string>(new []
            {
                "Milk Purchase",
                "Truck Sheet",
                "Local Sale",
                "Members",
                "Settings"
            });

            SelectedItem = "Milk Purchase";

            _currentPage = 0;

        }

        private async void ChangePageAsync()
        {
            if (SelectedItem == null)
                return;

            if(SelectedItem== "Milk Purchase")
                await _navigationService.NavigateAsync("MainNavigationPage/MilkPurchasePage");
            else if(SelectedItem == "Truck Sheet")
                await _navigationService.NavigateAsync("MainNavigationPage/TruckSheetPage");
            else if (SelectedItem == "Local Sale")
                await _navigationService.NavigateAsync("MainNavigationPage/LocalSalePage");
            else if (SelectedItem == "Members")
                await _navigationService.NavigateAsync("MainNavigationPage/MembersPage");
        }
    }
}
