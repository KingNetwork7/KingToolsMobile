using KingNetwork7.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KingNetwork7
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<MenuListViewItem> MenuItems { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            MenuItems = new List<MenuListViewItem>()
            {
                new MenuListViewItem(){Title = "CC Generator", Discription="Generate Credit Cards With Your Patterns .", IconName="ic_generatecc", PageAlias="CCGeneratorPage"},
                new MenuListViewItem(){Title="CC Checker", Discription="Check Generated Credit Cards .", IconName="ic_checkcc",PageAlias="CCCheckerPage" },
                new MenuListViewItem(){Title="Disposable Email", Discription="Receive Emails With Disposable Emails .", IconName="ic_mail", PageAlias="DisposableEmailPage"},
                new MenuListViewItem(){Title="Fake Name Generator", Discription="Get Fake Person Information for Authorize in Sites .", IconName="ic_person", PageAlias="FakeNameGeneratorPage"}
            };
            if (App.MainViewModel == null)
            {
                App.MainViewModel = new ViewModels.MainViewModel();
                App.MainNavigation = Navigation;
            }
            else
            {
                App.MainViewModel.IsBusy = false;
            }
            this.BindingContext = this;
            base.OnAppearing();
        }

        private void ExitButton_Tapped(object sender, EventArgs e)
        {
            Helpers.ExitHelper.Exit();
        }

        [Obsolete]
        private void WebSiteButton_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("Http://KingNetwork7.com/"));
        }

        [Obsolete]
        private void TelegramChannelButton_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("Https://t.me/King_Network7"));
        }

        private void MenuListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MenuListViewItem item = e.Item as MenuListViewItem;
            new Commons.Commands.NavigateCommand().Execute(item.PageAlias);
            MenuListView.SelectedItem = null;
        }
    }
}
