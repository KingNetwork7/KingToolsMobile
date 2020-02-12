using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KingNetwork7.Commons.Commands
{
    public class GetNewFakePersonInfos : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !App.MainViewModel.IsBusy;
        }

        public void Execute(object parameter)
        {
            App.MainViewModel.GetRawFakePerson();
        }
    }

    public class FakeInfoRefreshViewRefreshingCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!App.MainViewModel.IsBusy)
            {
                App.MainViewModel.IsBusy = true;
                App.MainViewModel.IsBusy = false;
            }
        }
    }
}
