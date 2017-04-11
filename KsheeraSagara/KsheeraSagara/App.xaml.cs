using Prism.Unity;
using KsheeraSagara.Views;
using Xamarin.Forms;
using KsheeraSagara.Data;

namespace KsheeraSagara
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        private static MilkDb _milkDb;

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("BasePage");//MainNavigationPage/MilkPurchasePage");
        }

        public static MilkDb MlkDb
        {
            get
            {
                if (_milkDb == null)
                {
                    _milkDb = new MilkDb(DependencyService.Get<IFileHelper>().GetLocalFilePath("MilkDb.db"));
                }
                return _milkDb;
            }
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
            Container.RegisterTypeForNavigation<MembersDisplay>();
        }


    }
}
