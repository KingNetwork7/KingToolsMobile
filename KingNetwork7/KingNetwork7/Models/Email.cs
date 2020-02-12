using KingNetwork7.Commons;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KingNetwork7.Models
{
    public class Email : ObservableBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _from;
        public string from
        {
            get { return _from; }
            set { SetProperty(ref _from, value); }
        }

        private string _subject;
        public string subject
        {
            get { return _subject; }
            set { SetProperty(ref _subject, value); }
        }

        private DateTime _date;
        public DateTime date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private object _attachments;
        public object attachments
        {
            get { return _attachments; }
            set { SetProperty(ref _attachments, value); }
        }

        private string _body;
        public string body
        {
            get { return _body; }
            set { SetProperty(ref _body, value); }
        }

        public HtmlWebViewSource bodyAsHtmlWebViewSource {
            get { return new HtmlWebViewSource() { Html = body.Replace(@"\n","") }; }
        }

        private string _textBody;
        public string textBody
        {
            get { return _textBody; }
            set { SetProperty(ref _textBody, value); }
        }

        private string _htmlBody;
        public string htmlBody
        {
            get { return _htmlBody; }
            set { SetProperty(ref _htmlBody, value); }
        }
    }

    public class ListEmail : ObservableBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _from;
        public string from
        {
            get { return _from; }
            set { SetProperty(ref _from, value); }
        }

        private string _subject;
        public string subject
        {
            get { return _subject; }
            set { SetProperty(ref _subject, value); }
        }

        private DateTime _date;
        public DateTime date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }
    }
}
