using KingNetwork7.Models;
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
    public partial class ViewEmailPage : ContentPage
    {
        int emailId;
        Email email;
        public ViewEmailPage(int id)
        {
            emailId = id;
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            await GetEmail();
            this.BindingContext = email;
            base.OnAppearing();
        }

        private async Task GetEmail()
        {
            email = await Helpers.DisposableEmailHelpers.GetEmail(emailId);
        }
    }
}