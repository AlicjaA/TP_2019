using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModel.Commands
{
    public class EditCommand: ICommand
    {
        #region Fields
        readonly Action<object> execute;
        readonly Predicate<object> canExecute;
        public event EventHandler CanExecuteChanged;
        #endregion

        #region Constructors
        public EditCommand(Action<object> executeDelegate, Predicate<object> canExecuteDelegate)
        {
            execute = executeDelegate;
            canExecute = canExecuteDelegate;
        }
        #endregion

        #region ICommandsMethods
        public bool CanExecute(object parameter)
        {
            return canExecute(this);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged.Invoke(this, null);
        }

        public void Execute(object parameter)
        {
            execute(this);
        }

        #endregion
    }
}
