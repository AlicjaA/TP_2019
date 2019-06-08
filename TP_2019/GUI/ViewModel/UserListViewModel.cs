
using System.Collections.ObjectModel;
using System.Windows.Controls;
using CasinoDataModelLibrary;
using CasinoData;

namespace GUI.ViewModel.Commands
{
    public partial class MainPageViewModel: Collective.ViewModel
    {
        #region Fields
        private User selectedUser;
        private ObservableCollection<User> users;


        #endregion

        #region Getters&Setters
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                EditUserCommand.RaiseCanExecuteChanged();
                DeleteUserCommand.RaiseCanExecuteChanged();
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


        #endregion



        #region CommandFields
        private AddCommand addUserCommand;
        private ActionCommand editUserCommand;
        private ActionCommand deleteUserCommand;



        #endregion

        #region CommandsMethods
        public AddCommand AddUserCommand
        {
            get
            {
                if (addUserCommand == null)
                {
                    addUserCommand = new AddCommand(e => AddUser());
                }
                return addUserCommand;
            }
        }

        public ActionCommand EditUserCommand
        {
            get
            {
                if (editUserCommand == null)
                {
                    editUserCommand = new ActionCommand(e => EditUser(selectedUser), e => selectedUser != null);
                }
                return editUserCommand;
            }
        }

        public ActionCommand DeleteUserCommand
        {
            get
            {
                if (DeleteUserCommand == null)
                {
                    deleteUserCommand = new ActionCommand(e => DeleteUser(selectedUser), e => selectedUser != null);
                }
                return DeleteUserCommand;
            }
        }

        #endregion


        #region Actions

        public void AddUser()
        {
            UserDetailsViewModel viewModel = new UserDetailsViewModel();
            viewModel.Actions = Collective.Action.ADD;

            
            IModalDialog dialog = UserProvider.Instance.Get<IModalDialog>();
            viewModel.SetCloseAction(e => dialog.Close());
            viewModel.SetAddAction(e => UsersList.Add((User)e));
            dialog.BindViewModel(viewModel);
            dialog.ShowDialog();
        }

        public void EditUser(User User)
        {
            UserViewModel viewModel = new UserViewModel(User);
            viewModel.Mode = Common.Mode.EDIT;

            IModalDialog dialog = UserProvider.Instance.Get<IModalDialog>();
            viewModel.SetCloseAction(e => dialog.Close());
            dialog.BindViewModel(viewModel);
            dialog.ShowDialog();
        }

        public void DeleteUser(User User)
        {
            IMessage messageService = MessagesProvider.GetService();
            MessageBoxResult result = messageService.Show("Do You want to delete?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result == MessageBoxResult.Cancel)
            {
                return;
            }
            DataRepository dataRepository = Data.DataRepository;

            bool state = false;
            Task.Run(() =>
            {
                state = dataRepository.DeleteUser(User);
            });

            if (state)
            {
                UsersList.Remove(User);
                messageService.Show(string.Format("User {0} successfully removed.", User), "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                messageService.Show(string.Format("Couldn't remove User {0}.", User), "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion
    }
}
