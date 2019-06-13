
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
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
                    addUserCommand = new AddCommand(e =>
                            Task.Run(() => { AddUser(); })
                        );
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
                    editUserCommand = new EditCommand(e => 
                    Task.Run(() => { EditUser(selectedUser); })
                        , e => selectedUser != null);
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
                    deleteUserCommand = new DeleteCommand(e => 
                    Task.Run(() => { DeleteUser(selectedUser); })
                        , e => selectedUser != null);
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
            IBaseWindowInteract window = DataProvider.Instance.Get<IBaseWindowInteract>();
            viewModel.SetCloseAction(e => window.Close());
            viewModel.SetAddAction(e => Users.Add((User)e));
            window.BindViewModel(viewModel);
            window.Show();
        }



       

        public void EditUser(User user)
        {
            UserDetailsViewModel viewModel = new UserDetailsViewModel(user);
            viewModel.Action = Collective.Action.EDIT;
            IBaseWindowInteract window = DataProvider.Instance.Get<IBaseWindowInteract>();
            int position=Users.IndexOf(user);
            viewModel.SetEditAction(e => Users[position]=user);
            viewModel.SetCloseAction(e => window.Close());
            window.BindViewModel(viewModel);
            window.Show();

        }

        public void DeleteUser(User user)
        {
            CasinoData.CasinoDataRepository dataRepository = CasinoDataModel.CasinoDataRepository;
            Task.Run(() =>
            {
                dataRepository.DeleteUser(user);
               
            });

            Application.Current.Dispatcher.Invoke((Action) delegate { Users.Remove(user); });
        }

        #endregion
    }
}
