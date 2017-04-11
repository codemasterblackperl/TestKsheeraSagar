using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KsheeraSagara.ViewModels
{
    public class MembersPageViewModel : BindableBase
    {
        public MembersPageViewModel()
        {

        }

        private string[] _memberType = new[]
        {
            "Share_Holder",
            "Non_Share_Holder",
            "Other"
        };

        private string[] _caste = new[]
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
        };

        private string[] _occupation = new[]
        {
            "Farmer",
            "Farm Labour",
            "Other"
        };

    }
}
