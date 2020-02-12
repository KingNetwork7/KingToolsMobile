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
    public partial class CCGeneratorPage : ContentPage
    {
        public CCGeneratorPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            App.MainViewModel.ResetCCGeneratorValues();
            this.BindingContext = App.MainViewModel;
            base.OnAppearing();
        }

        private void MonthPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            string newExMonth = picker.SelectedItem as string;
            App.MainViewModel.ExMonth = newExMonth;
        }

        private void YearPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            string newExYear = picker.SelectedItem as string;
            App.MainViewModel.ExYear = newExYear;
        }

        private void GeneratedCardsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            GeneratedCardsListView.SelectedItem = null;
        }
    }
}