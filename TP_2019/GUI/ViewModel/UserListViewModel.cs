
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using CasinoDataModelLibrary;
using CasinoData;
using GUI.Model;
using GUI.View;
using GUI.ViewModel.Commands;

namespace GUI.ViewModel
{
    public partial class MainPageViewModel : Collective.ViewModel
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

        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }


        #endregion


        #region CommandFields
        private AddCommand addUserCommand;
        private ActionCommand editUserCommand;
        private ActionCommand deleteUserCommand;
        private ActionCommand showUserCommand;



        #endregion

        #region CommandsMethods
        public ActionCommand ShowUserCommand
        {
            get
            {
                if (showUserCommand == null)
                {
                    showUserCommand = new ActionCommand(e => ShowUser(selectedUser), e => selectedUser != null);
                }
                return showUserCommand;
            }
        }

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
                if (deleteUserCommand == null)
                {
                    deleteUserCommand = new ActionCommand(e => DeleteUser(selectedUser), e => selectedUser != null);
                }
                return deleteUserCommand;
            }
        }

        #endregion


        #region Actions

        public void AddUser()
        {
            UserDetailsViewModel viewModel = new UserDetailsViewModel();
            viewModel.Action = Collective.Action.ADD;

            
            Page userDetails = new UserDetails();
           
            viewModel.SetAddAction(e => Users.Add((User)e));
            
        }

        public void ShowUser(User User)
        {
            UserDetailsViewModel viewModel = new UserDetailsViewModel(User);
            viewModel.Action = Collective.Action.SHOW;


            Page userDetails = new UserDetails();


        }

        public void EditUser(User User)
        {
            UserDetailsViewModel viewModel = new UserDetailsViewModel(User);
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
                Users.Remove(User);
            }
           
        }

        #endregion
    }
}
