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
        #endregion

        #region Constructors
        public AddCommand(Action<object> executeDelegate)
        {
            execute = executeDelegate;
        }
        #endregion

        #region ICommandsMembers
        public event EventHandler CanExecuteChanged;

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
