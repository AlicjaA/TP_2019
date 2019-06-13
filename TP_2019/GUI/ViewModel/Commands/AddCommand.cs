using System;
using System.ComponentModel;
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

        #region Constructors
        public AddCommand(Action<object> executeDelegate)
        {
            execute = executeDelegate;

        }
        #endregion

        #region ICommandsMembers
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
