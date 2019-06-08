
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using CasinoDataModelLibrary;
using CasinoData;
using GUI.Model;
using GUI.Providers;
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
        private EditCommand editUserCommand;
        private DeleteCommand deleteUserCommand;

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

        public EditCommand EditUserCommand
        {
            get
            {
                if (editUserCommand == null)
                {
                    editUserCommand = new EditCommand(e => EditUser(selectedUser), e => selectedUser != null);
                }
                return editUserCommand;
            }
        }

        public DeleteCommand DeleteUserCommand
        {
            get
            {
                if (deleteUserCommand == null)
                {
                    deleteUserCommand = new DeleteCommand(e => DeleteUser(selectedUser), e => selectedUser != null);
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
            IModelDialog window = DataProvider.Instance.Get<IModelDialog>();
            viewModel.SetCloseAction(e => window.Close());
            viewModel.SetAddAction(e => Users.Add((User)e));
            window.BindViewModel(viewModel);
            window.ShowDialog();

        }

       

        public void EditUser(User User)
        {
            UserDetailsViewModel viewModel = new UserDetailsViewModel(User);
            viewModel.Action = Collective.Action.EDIT;
            IModelDialog dialog = DataProvider.Instance.Get<IModelDialog>();
            int position=Users.IndexOf(User);
            viewModel.SetEditAction(e => Users[position]=User);
            viewModel.SetCloseAction(e => dialog.Close());
            dialog.BindViewModel(viewModel);
            dialog.ShowDialog();

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
