using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfApp
{
    class ChooseEllipseCommand : ICommand
    {
        private bool isExecutable = true;

        public EllipseCanvas Canvas { get; set;}
        public EllipseInfo Ellipse { get; set; }


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
            return isExecutable;
        }

        public void Execute(object parameter)
        {
            Canvas.CurrentEllipse = Ellipse;
        }

        public void SetExecutable(bool isExecutable)
        {
            this.isExecutable = isExecutable;
        }

        public override string ToString()
        {
            return Ellipse.Name;
        }
    }
}
