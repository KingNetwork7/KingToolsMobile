using Acr.UserDialogs;
using KingNetwork7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingNetwork7.Helpers
{
    public static class AlertsHelper
    {
        public static void ShowLongToast(string message)
        {
            UserDialogs.Instance.Toast(message, new TimeSpan(5));
        }

        public static void ShowShortToast(string message)
        {
            UserDialogs.Instance.Toast(message, new TimeSpan(3));
        }

        public static void ShowAlert(string title, string message, string okText)
        {
            UserDialogs.Instance.Alert(message, title: title, okText: okText);
        }

        public async static Task<PromptResult> PromptAsync(string message)
        {
            PromptResult result = await UserDialogs.Instance.PromptAsync(message);
            return result;
        }
    }
}
