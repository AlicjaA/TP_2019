﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModel.Commands
{

        public class EditCommand : ICommand
        {
            readonly Action<object> execute;
            readonly Predicate<object> canExecute;

            public EditCommand(Action<object> executeDelegate, Predicate<object> canExecuteDelegate)
            {
                execute = executeDelegate;
                canExecute = canExecuteDelegate;
            }

            public event EventHandler CanExecuteChanged;

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
        }
    }
