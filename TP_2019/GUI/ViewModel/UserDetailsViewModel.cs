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
        User user = new User();
        private int id;
        private string firstName;
        private string lastName;
        private string telephone;
        private int age;

        #endregion

        #region UserDataDefinitionsGetters&Setters
        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("ID");
            } 
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Telephone
        {
            get { return telephone; }
            set
            {
                telephone = value;
                OnPropertyChanged("Telephone");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }


        #endregion

        #region Constructors

        public UserDetailsViewModel(User user)
        {
            this.user = user;
            id = user.ID;
            firstName = user.FirstName;
            lastName = user.LastName;
            telephone = user.Telephone;
            age = user.Age;
        }

        public UserDetailsViewModel()
        {
        }

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
