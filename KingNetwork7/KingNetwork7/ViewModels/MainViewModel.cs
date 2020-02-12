using KingNetwork7.Commons;
using KingNetwork7.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KingNetwork7.ViewModels
{
    public class MainViewModel:ObservableBase
    {
        public MainViewModel()
        {
            LiveCards = new ObservableCollection<CreditCard>();
            BadCards = new ObservableCollection<CreditCard>();
            Emails = new ObservableCollection<ListEmail>();
            GeneratedCards = new ObservableCollection<string>();
            GeneratingPasswordDigits = 12;
            CurrentDisposableEmailUserName = Helpers.DisposableEmailHelpers.GetNewRandomDisposableEmailUserName();
            CurrentDisposableEmailAddress = CurrentDisposableEmailUserName + "@1secmail.com";
            GeneratedFakePersonCountry = FakePersonCountries.de;
            SelectedCountryIndex = 0;
            CountToGenerate = 20;
        }

        private bool _isBusy;
        public bool IsBusy {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        #region Password Generator
        private string _generatedPassword;
        public string GeneratedPassword
        {
            get { return _generatedPassword; }
            set { SetProperty(ref _generatedPassword, value); }
        }

        private int _generatingPasswordDigits;
        public int GeneratingPasswordDigits
        {
            get { return _generatingPasswordDigits; }
            set { SetProperty(ref _generatingPasswordDigits, value); }
        }
        #endregion

        #region CC Checker
        #region Colloctions

        private string _checkingCards;
        public string CheckingCards
        {
            get { return _checkingCards; }
            set { SetProperty(ref _checkingCards, value); }
        }

        private ObservableCollection<CreditCard> _liveCards;
        public ObservableCollection<CreditCard> LiveCards
        {
            get { return _liveCards; }
            set { SetProperty(ref _liveCards, value); }
        }

        private ObservableCollection<CreditCard> _badCards;
        public ObservableCollection<CreditCard> BadCards
        {
            get { return _badCards; }
            set { SetProperty(ref _badCards, value); }
        }

        #endregion

        public void ResetCCCheckValues()
        {
            LiveCards = new ObservableCollection<CreditCard>();
            BadCards = new ObservableCollection<CreditCard>();
            CheckingCards = string.Empty;
            IsBusy = false;
        }
        #endregion

        #region Disposable Email

        private string _currentDisposableEmailUserName;
        public string CurrentDisposableEmailUserName {
            get { return _currentDisposableEmailUserName; }
            set { SetProperty(ref _currentDisposableEmailUserName, value); } 
        }

        private string _currentDisposableEmailAddress;
        public string CurrentDisposableEmailAddress
        {
            get { return _currentDisposableEmailAddress; }
            set { SetProperty(ref _currentDisposableEmailAddress, value); }
        }

        #region Collections

        private ObservableCollection<ListEmail> _emails;
        public ObservableCollection<ListEmail> Emails {
            get { return _emails; }
            set { SetProperty(ref _emails, value); } 
        }

        #endregion

        public async Task ReloadEmails()
        {
            IsBusy = true;
            Emails.Clear();
            List<ListEmail> listEmails = await Helpers.DisposableEmailHelpers.GetEmails();
            foreach (var listEmail in listEmails)
            {
                Emails.Add(listEmail);
            }
            IsBusy = false;
        }

        public async void GetNewRandomDisposableEmail()
        {
            CurrentDisposableEmailUserName = Helpers.DisposableEmailHelpers.GetNewRandomDisposableEmailUserName();
            CurrentDisposableEmailAddress = CurrentDisposableEmailUserName + "@1secmail.com";
            await ReloadEmails();
        }

        public async void GetNewDisposableEmail(string newUserName)
        {
            if (!string.IsNullOrEmpty(newUserName))
            {
                CurrentDisposableEmailUserName = newUserName;
                CurrentDisposableEmailAddress = CurrentDisposableEmailUserName + "@1secmail.com";
                await ReloadEmails();
            }
        }

        #endregion

        #region FakeNameGenerator

        private string _rawGeneratedFakePerson;
        public string RawGeneratedFakePerson {
            get { return _rawGeneratedFakePerson; }
            set { SetProperty(ref _rawGeneratedFakePerson, value); } 
        }

        private FakePerson _generatedFakePerson;
        public FakePerson GeneratedFakePerson {
            get { return _generatedFakePerson; }
            set { SetProperty(ref _generatedFakePerson, value); } 
        }

        private FakePersonCountries _generatedFakePersonCountry;
        public FakePersonCountries GeneratedFakePersonCountry {
            get { return _generatedFakePersonCountry; }
            set { SetProperty(ref _generatedFakePersonCountry, value);} 
        }

        private int _selectedCountryIndex;
        public int SelectedCountryIndex
        {
            get { return _selectedCountryIndex; }
            set { SetProperty(ref _selectedCountryIndex, value); }
        }

        public async void GetRawFakePerson()
        {
            IsBusy = true;
            GeneratedFakePerson = await Helpers.FakePersonHelper.GetNewRawFakePerson(GeneratedFakePersonCountry);
            IsBusy = false;
        }

        #endregion

        #region CC Generator

        private string _bin;
        public string BIN 
        {
            get { return _bin; }
            set { SetProperty(ref _bin, value); }
        }

        private string _exMonth;
        public string ExMonth
        {
            get { return _exMonth; }
            set { SetProperty(ref _exMonth, value); }
        }

        private string _exYear;
        public string ExYear
        {
            get { return _exYear; }
            set { SetProperty(ref _exYear, value); }
        }

        private string _cvv;
        public string CVV
        {
            get { return _cvv; }
            set { SetProperty(ref _cvv, value); }
        }

        private int _countToGenerate;
        public int CountToGenerate
        {
            get { return _countToGenerate; }
            set { SetProperty(ref _countToGenerate, value); }
        }

        private ObservableCollection<string> _generatedCards;
        public ObservableCollection<string> GeneratedCards 
        {
            get { return _generatedCards; }
            set { SetProperty(ref _generatedCards, value); }
        }

        public void ResetCCGeneratorValues()
        {
            BIN = string.Empty;
            CVV = string.Empty;
            GeneratedCards.Clear();
        }

        public async void CopyGeneratedCards()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var card in GeneratedCards)
            {
                stringBuilder.AppendLine(card);
            }
            await Helpers.ClipboardHelper.SetClipboard(stringBuilder.ToString());
            Helpers.AlertsHelper.ShowShortToast("Cards Has Been Copied!");
        }
        #endregion
    }
}
