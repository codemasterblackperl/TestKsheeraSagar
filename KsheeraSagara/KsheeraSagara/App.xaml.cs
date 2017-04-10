using Prism.Unity;
using KsheeraSagara.Views;
using Xamarin.Forms;

namespace KsheeraSagara
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("BasePage");//MainNavigationPage/MilkPurchasePage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<BasePage>();
            Container.RegisterTypeForNavigation<MainNavigationPage>();
            Container.RegisterTypeForNavigation<MilkPurchasePage>();
            Container.RegisterTypeForNavigation<TruckSheetPage>();
            Container.RegisterTypeForNavigation<LocalSalePage>();
            Container.RegisterTypeForNavigation<MembersPage>();
            Container.RegisterTypeForNavigation<RateChartPage>();
        }
    }
}
