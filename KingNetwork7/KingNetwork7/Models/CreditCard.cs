using KingNetwork7.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingNetwork7.Models
{
    public class CreditCard:ObservableBase
    {
        private string _ccNumber;
        public string CCNumber { 
            get { return _ccNumber; } 
            set { SetProperty(ref _ccNumber, value); } 
        }

        private string _cVV;
        public string CVV {
            get { return _cVV; }
            set { SetProperty(ref _cVV, value); } 
        }

        private string _expireDate;
        public string ExpireDate {
            get { return _expireDate; }
            set { SetProperty(ref _expireDate, value); }
        }

        public string CVVAndExpireDate {
            get { return _cVV + " | " + _expireDate; }
        }

        public string RawCard {
            get { return CCNumber + "|" + ExpireDate + "|" + CVV; }
        }
    }
}
