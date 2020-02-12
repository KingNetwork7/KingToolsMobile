using KingNetwork7.Helpers;
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
    public partial class FakeNameGeneratorPage : ContentPage
    {
        public FakeNameGeneratorPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (App.MainViewModel.GeneratedFakePerson==null)
                App.MainViewModel.GetRawFakePerson();
            this.BindingContext = App.MainViewModel;
            foreach (FakePersonCountries country in Enum.GetValues(typeof(FakePersonCountries)))
                CountryPicker.Items.Add(country.GetCountryFullName());
            CountryPicker.SelectedIndex = App.MainViewModel.SelectedCountryIndex;
            base.OnAppearing();
        }

        private void CountryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.MainViewModel.SelectedCountryIndex = CountryPicker.SelectedIndex;
            App.MainViewModel.GeneratedFakePersonCountry = (FakePersonCountries)(Enum.GetValues(typeof(FakePersonCountries)).GetValue(App.MainViewModel.SelectedCountryIndex));
        }
    }
}