using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KingNetwork7.Commons.Commands
{
    public class CopyDisposableEmailAddressCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await Helpers.ClipboardHelper.SetClipboard(App.MainViewModel.CurrentDisposableEmailAddress);
            Helpers.AlertsHelper.ShowShortToast("Email Copied !");
        }
    }

    public class GetNewEmailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.MainViewModel.GetNewRandomDisposableEmail();
            Helpers.AlertsHelper.ShowShortToast("Email Address Changed !");
        }
    }

    public class ReloadEmails : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await App.MainViewModel.ReloadEmails();
            Helpers.AlertsHelper.ShowShortToast("Emails Reloaded !");
        }
    }

    public class ChangeEmailAddressCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            Acr.UserDialogs.PromptResult result = await Helpers.AlertsHelper.PromptAsync("Enter New Email User Name ...");
            if (result.Ok && !string.IsNullOrEmpty(result.Value))
            {
                App.MainViewModel.GetNewDisposableEmail(result.Value);
                Helpers.AlertsHelper.ShowShortToast("Email Address Changed !");
            }
        }
    }
}
