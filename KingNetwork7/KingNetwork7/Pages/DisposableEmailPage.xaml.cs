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
    public partial class DisposableEmailPage : ContentPage
    {
        public DisposableEmailPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            this.BindingContext = App.MainViewModel;
            await App.MainViewModel.ReloadEmails();
            base.OnAppearing();
        }
    }
}