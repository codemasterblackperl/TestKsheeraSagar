using KsheeraSagara.Helpers;
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
    public class MembersDisplayViewModel : BindableBase,INavigatedAware
    {
        private INavigationService _nav;
        private IPageDialogService _pds;

        public MembersDisplayViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _nav = navigationService;
            _pds = pageDialogService;

            FcMembers = new FastCollection<Member>();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            FcMembers.Clear();
            FcMembers.AddRange(SharedValues._LstMembers);
        }

        private FastCollection<Member> _fcMembers;

        public FastCollection<Member> FcMembers { get => _fcMembers; set =>SetProperty(ref _fcMembers , value); }

        public DelegateCommand AddNewMemberCommand => new DelegateCommand(AddNewMemberCmdAsync);

        private async void AddNewMemberCmdAsync()
        {
            await _nav.NavigateAsync("MembersPage");
        }
    }
}
