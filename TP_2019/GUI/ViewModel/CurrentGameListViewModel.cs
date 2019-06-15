using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CasinoDataModelLibrary;
using GUI.Model;
using GUI.Providers;
using GUI.ViewModel.Commands;

namespace GUI.ViewModel
{
    public partial class MainPageViewModel : Collective.ViewModel
    {
        #region Fields
        private CurrentGame selectedCurrentGame;
        private ObservableCollection<CurrentGame> currentGames;



        #endregion


        #region Getters&Setters


        public CurrentGame SelectedCurrentGame
        {
            get { return selectedCurrentGame; }
            set
            {
                selectedCurrentGame = value;
                EditCurrentGameCommand.RaiseCanExecuteChanged();
                DeleteCurrentGameCommand.RaiseCanExecuteChanged();
                ShowCurrentGameCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<CurrentGame> CurrentGames
        {
            get => currentGames;
            set
            {
                currentGames = value;
                OnPropertyChanged("CurrentGames");
            }
        }


        #endregion


        #region CommandFields
        private BaseCommand addCurrentGameCommand;
        private DataChangeCommand editCurrentGameCommand;
        private DataChangeCommand deleteCurrentGameCommand;
        private DataChangeCommand showCurrentGameCommand;

        #endregion

        #region CommandsMethods

        public BaseCommand AddCurrentGameCommand
        {
            get
            {
                if (addCurrentGameCommand == null)
                {
                    addCurrentGameCommand = new BaseCommand(e =>
                                Task.Run(() => { AddCurrentGame(); }), null
                            );
                }
                return addCurrentGameCommand;
            }
        }



        public DataChangeCommand EditCurrentGameCommand
        {
            get
            {
                if (editCurrentGameCommand == null)
                {
                    editCurrentGameCommand = new DataChangeCommand(e =>
                        Task.Run(() => { EditCurrentGame(selectedCurrentGame); })
                            , e => selectedCurrentGame != null);
                }
                return editCurrentGameCommand;
            }
        }

        public DataChangeCommand ShowCurrentGameCommand
        {
            get
            {
                if (showCurrentGameCommand == null)
                {
                    showCurrentGameCommand = new DataChangeCommand(e =>
                                Task.Run(() => { ShowCurrentGame(selectedCurrentGame); }),
                            e => selectedCurrentGame != null);
                }
                return showCurrentGameCommand;
            }
        }

        public DataChangeCommand DeleteCurrentGameCommand
        {
            get
            {
                if (deleteCurrentGameCommand == null)
                {
                    deleteCurrentGameCommand = new DataChangeCommand(e =>
                        Task.Run(() => { DeleteCurrentGame(selectedCurrentGame); })
                            , e => selectedCurrentGame != null);
                }
                return deleteCurrentGameCommand;
            }
        }

        #endregion


        #region Actions

        public void AddCurrentGame()
        {

            CurrentGameDetailsViewModel viewModel = new CurrentGameDetailsViewModel();
            viewModel.Action= Action = Collective.Action.ADD;
            IBaseWindowInteract window = CurrentGameProvider.Instance.Get<IBaseWindowInteract>();
            viewModel.SetCloseAction(e => window.Close());
            viewModel.SetAddAction(e => CurrentGames.Add((CurrentGame)e));
            window.BindViewModel(viewModel);
            window.Show();
        }





        public void EditCurrentGame(CurrentGame currentGame)
        {
            CurrentGameDetailsViewModel viewModel = new CurrentGameDetailsViewModel(currentGame, currentGame.Game) { Action = Collective.Action.EDIT };
            IBaseWindowInteract window = CurrentGameProvider.Instance.Get<IBaseWindowInteract>();
            int position = CurrentGames.IndexOf(currentGame);
            viewModel.SetEditAction(e => CurrentGames[position] = currentGame);
            viewModel.SetCloseAction(e => window.Close());
            window.BindViewModel(viewModel);
            window.Show();

        }

        public void DeleteCurrentGame(CurrentGame currentGame)
        {
            CasinoData.CasinoDataRepository dataRepository = CasinoDataModel.CasinoDataRepository;
            Task.Run(() =>
            {
                dataRepository.DeleteCurrentGame(currentGame);

            });

            Application.Current.Dispatcher.Invoke((Action)delegate { CurrentGames.Remove(currentGame); });
        }

        public void ShowCurrentGame(CurrentGame currentGame)
        {
            CurrentGameDetailsViewModel viewModel = new CurrentGameDetailsViewModel(currentGame, currentGame.Game) { Action = Collective.Action.SHOW };
            IBaseWindowInteract window = CurrentGameProvider.Instance.Get<IBaseWindowInteract>();
            viewModel.SetCloseAction(e => window.Close());
            window.BindViewModel(viewModel);
            window.Show();

        }

        #endregion
    }
}
