using KingNetwork7.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingNetwork7.Models
{
    public class FakePerson:ObservableBase
    {
        private string _name;
        public string Name {
            get { return _name; }
            set { SetProperty(ref _name, value); } 
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set { SetProperty(ref _country, value); }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        private string _postCode;
        public string PostCode
        {
            get { return _postCode; }
            set { SetProperty(ref _postCode, value); }
        }

        private string _gender;
        public string Gender
        {
            get { return _gender; }
            set { SetProperty(ref _gender, value); }
        }

        private string _dateOfBirth;
        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set { SetProperty(ref _dateOfBirth, value); }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        private string _bankName;
        public string BankName
        {
            get { return _bankName; }
            set { SetProperty(ref _bankName, value); }
        }

        private string _bankCode;
        public string BankCode
        {
            get { return _bankCode; }
            set { SetProperty(ref _bankCode, value); }
        }

        private string _BIC;
        public string BIC
        {
            get { return _BIC; }
            set { SetProperty(ref _BIC, value); }
        }

        private string _IBAN;
        public string IBAN
        {
            get { return _IBAN; }
            set { SetProperty(ref _IBAN, value); }
        }

        private string _accountNumber;
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { SetProperty(ref _accountNumber, value); }
        }


        private string _qualification;
        public string Qualification
        {
            get { return _qualification; }
            set { SetProperty(ref _qualification, value); }
        }

        private string _institution;
        public string Institution
        {
            get { return _institution; }
            set { SetProperty(ref _institution, value); }
        }


        private string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set { SetProperty(ref _companyName, value); }
        }

        private string _companyAddress;
        public string CompanyAddress
        {
            get { return _companyAddress; }
            set { SetProperty(ref _companyAddress, value); }
        }


        private string _vehicle;
        public string Vehicle
        {
            get { return _vehicle; }
            set { SetProperty(ref _vehicle, value); }
        }

        private string _VIN;
        public string VIN
        {
            get { return _VIN; }
            set { SetProperty(ref _VIN, value); }
        }
    }

    public enum FakePersonCountries
    {
        de, br, nl, us, es, au, ph, ro, it,ca, se
    }
}
