using KingNetwork7.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KingNetwork7.Commons.Commands
{
    public class NavigateToViewEmailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (Helpers.ConnectionHelper.HaveConnection())
            {
                int id = (int)parameter;
                App.MainNavigation.PushAsync(new ViewEmailPage(id));
            }
            else
            {
                Helpers.AlertsHelper.ShowAlert("Connection Not Found!", "This Service Needs Internet Connection . Check Your Internet Connection and Try again .", "OK");
            }
        }
    }

    public class NavigateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            string pageName = parameter as string;
            switch (pageName)
            {
                case "PasswordGeneratorPage":
                    {
                        await App.MainNavigation.PushAsync(new PasswordGenerator());
                        break;
                    }
                case "CCGeneratorPage":
                    {
                        await App.MainNavigation.PushAsync(new CCGeneratorPage());
                        break;
                    }
                case "CCCheckerPage":
                    {
                        if (Helpers.ConnectionHelper.HaveConnection())
                        {
                            await App.MainNavigation.PushAsync(new CCCheckerPage());
                        }
                        else
                        {
                            Helpers.AlertsHelper.ShowAlert("Connection Not Found!", "This Service Needs Internet Connection . Check Your Internet Connection and Try again .", "OK");
                        }
                        break;
                    }
                case "DisposableEmailPage":
                    {
                        if (Helpers.ConnectionHelper.HaveConnection())
                        {
                            await App.MainNavigation.PushAsync(new DisposableEmailPage());
                        }
                        else
                        {
                            Helpers.AlertsHelper.ShowAlert("Connection Not Found!", "This Service Needs Internet Connection . Check Your Internet Connection and Try again .", "OK");
                        }
                        break;
                    }
                case "FakeNameGeneratorPage":
                    {
                        if (Helpers.ConnectionHelper.HaveConnection())
                        {
                            await App.MainNavigation.PushAsync(new FakeNameGeneratorPage());
                        }
                        else
                        {
                            Helpers.AlertsHelper.ShowAlert("Connection Not Found!", "This Service Needs Internet Connection . Check Your Internet Connection and Try again .", "OK");
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
