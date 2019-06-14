using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModel.Commands
{
    public class AddCommand : ICommand
    {
        #region Fields

        private Action<object> execute;
        public event EventHandler CanExecuteChanged;

        #endregion

        #region Methods

        public AddCommand(Action<object> executeDelegate)
        {
            execute = executeDelegate;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute(this);
        }
        #endregion
    }

}
