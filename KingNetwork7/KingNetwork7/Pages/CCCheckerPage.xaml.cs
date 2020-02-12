using KingNetwork7.Helpers;
using KingNetwork7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KingNetwork7.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CCCheckerPage : ContentPage
    {
        public CCCheckerPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            App.MainViewModel.ResetCCCheckValues();
            this.BindingContext = App.MainViewModel;
            base.OnAppearing();
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            if (!App.MainViewModel.IsBusy)
                App.MainViewModel.CheckingCards = string.Empty;
        }

        private async void btnPaste_Clicked(object sender, EventArgs e)
        {
            if (!App.MainViewModel.IsBusy)
            {
                var clipboardText = await ClipboardHelper.GetClipboard();
                if (!string.IsNullOrEmpty(clipboardText))
                    App.MainViewModel.CheckingCards += "\n" + clipboardText;
            }
        }

        private async void Lives_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            CreditCard card = e.Item as CreditCard;
            Lives.SelectedItem = null;
            await ClipboardHelper.SetClipboard(card.RawCard);
            AlertsHelper.ShowShortToast("Card Copied !");
        }

        private async void Bads_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            CreditCard card = e.Item as CreditCard;
            Bads.SelectedItem = null;
            await ClipboardHelper.SetClipboard(card.RawCard);
            AlertsHelper.ShowShortToast("Card Copied !");
        }
    }
}