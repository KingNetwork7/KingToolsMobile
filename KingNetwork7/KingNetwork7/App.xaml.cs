using KingNetwork7.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KingNetwork7
{
    public partial class App : Application
    {
        public static MainViewModel MainViewModel { get; set; }
        public static INavigation MainNavigation { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor=Color.FromHex("#240042") };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
