using KingNetwork7.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KingNetwork7.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordGenerator : ContentPage
    {
        public PasswordGenerator()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            App.MainViewModel.GeneratedPassword = PasswordHelper.GeneratePassword(App.MainViewModel.GeneratingPasswordDigits);
            this.BindingContext = App.MainViewModel;
            base.OnAppearing();
        }

        private async void btnCopyPassword_Clicked(object sender, EventArgs e)
        {
            await ClipboardHelper.SetClipboard(App.MainViewModel.GeneratedPassword);
            AlertsHelper.ShowShortToast("Password Copied !");
        }
    }
}