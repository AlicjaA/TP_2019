using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CasinoDataModelLibrary;
using CasinoData;

namespace GUI.ViewModel.Commands
{
    public partial class MainPageViewModel
    {
        private User selectedUser;
        private ObservableCollection<User> users;

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                EditUserCommand.RaiseCanExecuteChanged();
                RemoveUserCommand.RaiseCanExecuteChanged();
            }
        }

       


        public ObservableCollection<User> UserList
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged("UsersList");
            }
        }
    }
}
