using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CasinoDataModelLibrary;
using GUI.Model;
using GUI.ViewModel.Commands;
using Action = GUI.Collective.Action;

namespace GUI.ViewModel
{
    public class CurrentGameDetailsViewModel : Collective.ViewModel, INotifyPropertyChanged, IDataErrorInfo
    {

        #region Fields

        private Action<object> addDelegate;
        private Action<object> editDelegate;
        private Action<object> closeDelegate;
        private Action<object> showDelegate;
        public event PropertyChangedEventHandler PropertyChanged;


        private List<Game> games;
        CurrentGame currentGame = new CurrentGame();
        private Game game;
        private int howManyPlayers;
        private DateTimeOffset startGameTime;
        private DateTimeOffset endGameTime;
        private ICommand saveCommand;
        private ICommand cancelCommand;

        #endregion

        #region CurrentGameDataDefinitionsGetters&Setters

        public int HowManyPlayers
        {
            get => howManyPlayers;
            set => howManyPlayers = value;
        }

        public List<Game> Games
        {
            get => games;
            set => games = value;
        }



        public Game Game
        {
            get => game;
            set => game = value;
        }



        public DateTimeOffset StartGameTime
        {
            get => startGameTime;
            set => startGameTime = value;
        }

        public DateTimeOffset EndGameTime
        {
            get => endGameTime;
            set => endGameTime = value;
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
                if (fieldName == "Game")
                {
                    if (Game.Equals(null))
                        result = "Pole nie może być puste!";
                }

                if (fieldName == "HowManyPalyers")
                {
                    if (HowManyPlayers.Equals(null))
                        result = "Pole nie może być puste!";
                }

                if (fieldName == "StartGameTime")
                {
                    if (StartGameTime.Equals(null))
                        result = "Pole nie może być puste!";
                }

                if (fieldName == "EndGameTime")
                {
                    if (EndGameTime.Equals(null))
                        result = "Pole nie może być puste!";
                }

                return result;
            }
        }



        #endregion



        #region Constructors

        public CurrentGameDetailsViewModel(CurrentGame currentGame)
        {
            this.currentGame = currentGame;
            this.Game = currentGame.Game;
            this.HowManyPlayers = currentGame.HowManyPlayers;
            this.StartGameTime = currentGame.StartGameTime;
            this.EndGameTime = currentGame.EndGameTime;
        }

        public CurrentGameDetailsViewModel()
        {
        }

        #endregion



        #region Methods

        private void OnSave()
        {
            CasinoData.CasinoDataRepository dataRepository = CasinoDataModel.CasinoDataRepository;
            CurrentGame currentGameToSave = new CurrentGame()
            {
                Game = Game,
                HowManyPlayers = HowManyPlayers,
                StartGameTime = StartGameTime,
                EndGameTime = EndGameTime
            };

            switch (Action)
            {
                case Action.ADD:
                    {
                        Task.Run(() => { dataRepository.AddCurrentGame(currentGameToSave); });

                        addDelegate(currentGameToSave);

                        break;
                    }
                case Action.EDIT:
                    {
                        Task.Run(() =>
                        {
                            dataRepository.UpdateCurrentGame(currentGame, currentGameToSave);
                        });
                        editDelegate(currentGameToSave);

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