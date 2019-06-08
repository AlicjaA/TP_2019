using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GUI.ViewModel.Commands;
using CasinoData;
using CasinoDataModelLibrary;

namespace GUI.ViewModel
{

    public class UserDetailsViewModel: Collective.ViewModel
    {


        #region Fields
        private Page displayPage;
        private Action<object> addDelegate;

        #endregion

        #region Methods
        public Page DisplayPage
        {
            get => displayPage;
            set
            {
                if (displayPage == value)
                {
                    return;
                }

                this.displayPage = value;
                base.OnPropertyChanged("DisplayPage");
            }
        }


        #endregion


        #region Commands

        private ICommand saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new ActionCommand(e => OnSave(), null);
                }
                return saveCommand;
            }
        }

        private void OnSave()
        {
            
        }

        #endregion

        #region Actions

        public void SetAddAction(Action<object> addDelegate)
        {
            this.addDelegate = addDelegate;
        }

        #endregion







    }

}
