
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
                ShowUserCommand.RaiseCanExecuteChanged();
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
        private BaseCommand addUserCommand;
        private DataChangeCommand editUserCommand;
        private DataChangeCommand deleteUserCommand;
        private DataChangeCommand showUserCommand;

        #endregion

        #region CommandsMethods

        public BaseCommand AddUserCommand
        {
            get
            {
                if (addUserCommand == null)
                {
                    addUserCommand = new BaseCommand(e =>
                            Task.Run(() => { AddUser(); }), null
                        );
                }
                return addUserCommand;
            }
        }

        

        public DataChangeCommand EditUserCommand
        {
            get
            {
                if (editUserCommand == null)
                {
                    editUserCommand = new DataChangeCommand(e => 
                    Task.Run(() => { EditUser(selectedUser); })
                        , e => selectedUser != null);
                }
                return editUserCommand;
            }
        }

        public DataChangeCommand ShowUserCommand
        {
            get
            {
                if (showUserCommand == null)
                {
                    showUserCommand = new DataChangeCommand(e =>
                            Task.Run(() => { ShowUser(selectedUser); }),
                        e => selectedUser != null);
                }
                return showUserCommand;
            }
        }

        public DataChangeCommand DeleteUserCommand
        {
            get
            {
                if (deleteUserCommand == null)
                {
                    deleteUserCommand = new DataChangeCommand(e => 
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

            UserDetailsViewModel viewModel = new UserDetailsViewModel {Action = Collective.Action.ADD};
            IBaseWindowInteract window = DataProvider.Instance.Get<IBaseWindowInteract>();
            viewModel.SetCloseAction(e => window.Close());
            viewModel.SetAddAction(e => Users.Add((User)e));
            window.BindViewModel(viewModel);
            window.Show();
        }



       

        public void EditUser(User user)
        {
            UserDetailsViewModel viewModel = new UserDetailsViewModel(user) {Action = Collective.Action.EDIT};
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

        public void ShowUser(User user)
        {
            UserDetailsViewModel viewModel = new UserDetailsViewModel(user) { Action = Collective.Action.SHOW };
            IBaseWindowInteract window = DataProvider.Instance.Get<IBaseWindowInteract>();
            viewModel.SetCloseAction(e => window.Close());
            window.BindViewModel(viewModel);
            window.Show();

        }

        #endregion
    }
}
