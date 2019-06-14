using System;
using System.Threading.Tasks;
using GUI.Model;
using GUI.Providers;
using GUI.ViewModel.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using CasinoDataModelLibrary;


namespace GUI.ViewModel
{

        public partial class MainPageViewModel : Collective.ViewModel
        {
            #region Fields
            private Game selectedGame;
            private ObservableCollection<Game> games;



            #endregion


            #region Getters&Setters


            public Game SelectedGame
            {
                get { return selectedGame; }
                set
                {
                    selectedGame = value;
                    EditGameCommand.RaiseCanExecuteChanged();
                    DeleteGameCommand.RaiseCanExecuteChanged();
                    ShowGameCommand.RaiseCanExecuteChanged();
                }
            }

            public ObservableCollection<Game> Games
            {
                get => games;
                set
                {
                    games = value;
                    OnPropertyChanged("Games");
                }
            }


            #endregion


            #region CommandFields
            private BaseCommand addGameCommand;
            private DataChangeCommand editGameCommand;
            private DataChangeCommand deleteGameCommand;
            private DataChangeCommand showGameCommand;

            #endregion

            #region CommandsMethods

            public BaseCommand AddGameCommand
        {
                get
                {
                    if (addGameCommand == null)
                    {
                    addGameCommand = new BaseCommand(e =>
                                Task.Run(() => { AddGame(); }), null
                            );
                    }
                    return addGameCommand;
                }
            }



            public DataChangeCommand EditGameCommand
        {
                get
                {
                    if (editGameCommand == null)
                    {
                    editGameCommand = new DataChangeCommand(e =>
                        Task.Run(() => { EditGame(selectedGame); })
                            , e => selectedGame != null);
                    }
                    return editGameCommand;
                }
            }

            public DataChangeCommand ShowGameCommand
        {
                get
                {
                    if (showGameCommand == null)
                    {
                    showGameCommand = new DataChangeCommand(e =>
                                Task.Run(() => { ShowGame(selectedGame); }),
                            e => selectedGame != null);
                    }
                    return showGameCommand;
                }
            }

            public DataChangeCommand DeleteGameCommand
        {
                get
                {
                    if (deleteGameCommand == null)
                    {
                    deleteGameCommand = new DataChangeCommand(e =>
                        Task.Run(() => { DeleteGame(selectedGame); })
                            , e => selectedGame != null);
                    }
                    return deleteGameCommand;
                }
            }

            #endregion


            #region Actions

            public void AddGame()
            {

                GameDetailsViewModel viewModel = new GameDetailsViewModel { Action = Collective.Action.ADD };
                IBaseWindowInteract window = GameProvider.Instance.Get<IBaseWindowInteract>();
                viewModel.SetCloseAction(e => window.Close());
                viewModel.SetAddAction(e => Games.Add((Game)e));
                window.BindViewModel(viewModel);
                window.Show();
            }





            public void EditGame(Game game)
            {
                GameDetailsViewModel viewModel = new GameDetailsViewModel(game) { Action = Collective.Action.EDIT };
                IBaseWindowInteract window = GameProvider.Instance.Get<IBaseWindowInteract>();
                int position = Games.IndexOf(game);
                viewModel.SetEditAction(e => Games[position] = game);
                viewModel.SetCloseAction(e => window.Close());
                window.BindViewModel(viewModel);
                window.Show();

            }

            public void DeleteGame(Game game)
            {
                CasinoData.CasinoDataRepository dataRepository = CasinoDataModel.CasinoDataRepository;
                Task.Run(() =>
                {
                    dataRepository.DeleteGame(game);

                });

                Application.Current.Dispatcher.Invoke((Action)delegate { Games.Remove(game); });
            }

            public void ShowGame(Game game)
            {
                GameDetailsViewModel viewModel = new GameDetailsViewModel(game) { Action = Collective.Action.SHOW };
                IBaseWindowInteract window = GameProvider.Instance.Get<IBaseWindowInteract>();
                viewModel.SetCloseAction(e => window.Close());
                window.BindViewModel(viewModel);
                window.Show();

            }

            #endregion
        }
   

}
