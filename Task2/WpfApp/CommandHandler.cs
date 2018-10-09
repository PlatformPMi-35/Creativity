using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfApp
{
    public class CommandHandler : ICommand
    {
        private Action action;
        private bool canExecute;

        public CommandHandler(Action action_, bool canExecute_)
        {
            this.action = action_;
            this.canExecute = canExecute_;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute;
        }

        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
