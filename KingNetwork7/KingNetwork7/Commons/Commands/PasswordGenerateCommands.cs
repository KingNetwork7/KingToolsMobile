using KingNetwork7.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KingNetwork7.Commons.Commands
{
    public class GenerateNewPasswordCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.MainViewModel.GeneratedPassword = PasswordHelper.GeneratePassword(App.MainViewModel.GeneratingPasswordDigits);
        }
    }
}
