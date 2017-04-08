using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KsheeraSagara.ViewModels
{
    public class TruckSheetPageViewModel : BindableBase
    {
        private INavigationService _navigationService;
        private IPageDialogService _pageDialogService;

        public TruckSheetPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            ToDaysDate = DateTime.Now;

            if (ToDaysDate.ToString("tt") == "AM")
            {
                Session = "Morning \u25BC";
            }
            else
            {
                Session = "Evening \u25BC";
            }

        }

        private DateTime _toDaysDate;
        private string _session;


        public DateTime ToDaysDate { get => _toDaysDate; set => SetProperty(ref _toDaysDate, value); }
        public string Session { get => _session; set => SetProperty(ref _session, value); }


        public DelegateCommand SessionCommand => new DelegateCommand(SessionCommandAsync);



        private async void SessionCommandAsync()
        {
            var res = await _pageDialogService.DisplayActionSheetAsync("Session:", "Cancel", "", new[]
            {
                "Morning",
                "Evening"
            });

            if (res == "Cancel")
                return;
            Session = res + "\u25BC";
        }
    }
}
