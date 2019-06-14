﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using GUI.ViewModel.Commands;
using CasinoData;
using CasinoDataModelLibrary;
using GUI.Model;
using Action = GUI.Collective.Action;

namespace GUI.ViewModel
{

    public class UserDetailsViewModel: Collective.ViewModel, INotifyPropertyChanged, IDataErrorInfo
    {

        #region Fields
        private Action<object> addDelegate;
        private Action<object> editDelegate;
        private Action<object> closeDelegate;
        private Action<object> showDelegate;
        //private Action<object> deleteDelegate;
        public event PropertyChangedEventHandler PropertyChanged;


        User user = new User();
        private int id;
        private string firstName;
        private string lastName;
        private string telephone;
        private int age;
        private ICommand saveCommand;
        private ICommand cancelCommand;

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

        #region Erorr

        public string Error
        {
            get { return String.Empty; }
        }

        public string this[string fieldName]
        {
            get
            {
                string result = null;
                if (fieldName == "FirstName")
                {
                    if (string.IsNullOrEmpty(FirstName))
                        result = "Pole nie może być puste!";
                }

                if (fieldName == "LastName")
                {
                    if (string.IsNullOrEmpty(LastName))
                        result = "Pole nie może być puste!";
                }

                if (fieldName == "Telephone")
                {
                    if (string.IsNullOrEmpty(Telephone))
                        result = "Pole nie może być puste!";
                }

                if (fieldName == "Age")
                {
                    if (Age.Equals(null))
                        result = "Pole nie może być puste!";
                }
                return result;
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
        private void OnSave()
        {
            CasinoData.CasinoDataRepository dataRepository = CasinoDataModel.CasinoDataRepository;
            User userToSave = new User()
            {
                ID = ID,
                FirstName = FirstName,
                LastName = LastName,
                Telephone = Telephone,
                Age = Age
            };

            switch (Action)
            {
                case Action.ADD:
                {
                    Task.Run(() => { dataRepository.AddUser(userToSave); });

                    addDelegate(userToSave);

                    break;
                }
                case Action.EDIT:
                {
                    Task.Run(() => { dataRepository.UpdateUser(user, userToSave); });
                    editDelegate(userToSave);

                    break;
                }
               
                default:
                {
                    break;
                }
            }
            closeDelegate(this);
        }

        private void OnCancel()
        {
            closeDelegate(this);
        }

        virtual protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

       

        #endregion


        #region Commands



        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = new BaseCommand(e => OnSave(), null);
                }
                return saveCommand;
            }
        }

        
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new BaseCommand(e => OnCancel(), null);
                }
                return cancelCommand;
            }
        }



        #endregion

        #region Actions

        public void SetAddAction(Action<object> addDelegate)
        {

            this.addDelegate = addDelegate;
        }

        public void SetCloseAction(Action<object> closeDelegate)
        {
            this.closeDelegate = closeDelegate;
        }

        public void SetEditAction(Action<object> editDelegate)
        {
            this.editDelegate = editDelegate;
        }

        #endregion


    }

}
