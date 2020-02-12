using KingNetwork7.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KingNetwork7.Commons.Commands
{
    public class CheckCreditCardsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !App.MainViewModel.IsBusy;
        }

        public void Execute(object parameter)
        {
            if (parameter != null && !App.MainViewModel.IsBusy)
            {
                App.MainViewModel.IsBusy = true;

                string rawCards = parameter as string;
                string[] Cards = rawCards.Split(new string[] { "\n" }, StringSplitOptions.None);
                Task.Run(new Action(()=>
                {
                    CreditCardsHelper.CheckCreditCards(Cards);
                }));
            }
        }
    }

    public class GenerateCreditCardsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !App.MainViewModel.IsBusy;
        }

        public void Execute(object parameter)
        {
            if (App.MainViewModel.BIN != null)
            {
                if (App.MainViewModel.BIN.Length > 16)
                {
                    AlertsHelper.ShowAlert("Invalid BIN", "Invalid Bin Entered !\nCheck BIN And Try Again !", "OK");
                    return;
                }

                while (App.MainViewModel.BIN.Length < 16)
                {
                    App.MainViewModel.BIN += "x";
                }

                if (App.MainViewModel.BIN.Length == 16)
                {
                    App.MainViewModel.IsBusy = true;

                    App.MainViewModel.GeneratedCards.Clear();

                    Task.Run(new Action(() =>
                    {
                        CreditCardsHelper.GenerateCreditCards(
                            App.MainViewModel.BIN,
                            App.MainViewModel.CVV,
                            App.MainViewModel.ExMonth,
                            App.MainViewModel.ExYear,
                            App.MainViewModel.CountToGenerate
                        );
                    }));
                }
            }
        }
    }

    public class CopyGeneratedCardsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.MainViewModel.CopyGeneratedCards();
        }
    }
}
