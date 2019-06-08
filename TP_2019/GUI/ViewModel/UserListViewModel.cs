
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using CasinoDataModelLibrary;
using CasinoData;
using GUI.Model;
using GUI.View;

namespace GUI.ViewModel.Commands
{
    public partial class MainPageViewModel: Collective.ViewModel
    {
        #region Fields
        private User selectedUser;
        private ObservableCollection<User> users;
        UserDetailsViewModel viewModel = new UserDetailsViewModel();

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
            viewModel.Action = Collective.Action.ADD;

            
            Page userDetails = new UserDetails();
           
            viewModel.SetAddAction(e => UserList.Add((User)e));
            
        }

        public void EditUser(User User)
        {
            viewModel.Action = Collective.Action.EDIT;

            Page userDetails = new UserDetails();
        }

        public void DeleteUser(User User)
        {
            bool ifDeleted = false;
            CasinoData.CasinoDataRepository dataRepository = CasinoDataModel.CasinoDataRepository;

            
            Task.Run(() =>
            {
                ifDeleted = dataRepository.DeleteUser(User);
            });

            if (ifDeleted)
            {
                UserList.Remove(User);
            }
           
        }

        #endregion
    }
}
