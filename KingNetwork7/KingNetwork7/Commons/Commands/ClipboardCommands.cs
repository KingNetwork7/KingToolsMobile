using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KingNetwork7.Commons.Commands
{
    public class CopyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            string text = parameter as string;
            await Helpers.ClipboardHelper.SetClipboard(text);
            Helpers.AlertsHelper.ShowShortToast("Copied !");
        }
    }
}
