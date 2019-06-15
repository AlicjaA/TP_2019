using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using CasinoDataModelLibrary;
using GUI.Model;
using GUI.ViewModel.Commands;
using Action = GUI.Collective.Action;

namespace GUI.ViewModel
{
    public class GameDetailsViewModel : Collective.ViewModel, INotifyPropertyChanged, IDataErrorInfo
    {

        #region Fields
        private Action<object> addDelegate;
        private Action<object> editDelegate;
        private Action<object> closeDelegate;
        private Action<object> showDelegate;
        //private Action<object> deleteDelegate;
        public event PropertyChangedEventHandler PropertyChanged;


        Game game = new Game();
        private string title;
        private int maxPlayers;
        private int minPlayers;
        private double maxPrize;
        private double minBet;
        private ICommand saveCommand;
        private ICommand cancelCommand;

        #endregion

        #region GameDataDefinitionsGetters&Setters


        public String Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public int MaxPlayers
        {
            get => maxPlayers;
            set
            {
                maxPlayers = value;
                OnPropertyChanged("MaxPlayers");
            }
            
        }

        public int MinPlayers
        {
            get => minPlayers;
            set
            {
                minPlayers = value;
                OnPropertyChanged("MinPlayers");
            }

        }

        public double MaxPrize
        {
            get => maxPrize;
            set
            {
                maxPrize = value;
                OnPropertyChanged("MaxPrize");
            }
        }

        public double MinBet
        {
            get => minBet;
            set
            {
                minBet = value;
                OnPropertyChanged("MinBet");
            }
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
                if (fieldName == "Title")
                {
                    if (string.IsNullOrEmpty(Title))
                        result = "Pole nie może być puste!";
                }

                if (fieldName == "MinBet")
                {
                    if (MinBet.Equals(null))
                    {
                        result = "Pole nie może być puste!";
                    }

                   
                }

                if (fieldName == "MaxPrize")
                {
                    if (MaxPrize.Equals(null))
                    {
                        result = "Pole nie może być puste!";
                    }
                        
                    
                }

                if (fieldName == "MaxPlayers")
                {
                    if (MaxPlayers.Equals(null))
                    {
                        result = "Pole nie może być puste!";
                    }
                   
                    else if (MinPlayers > MaxPlayers)
                    {
                        result = "Min Graczy nie może być więcej niż Max Graczy";
                    }

                }

                if (fieldName == "MinPlayers")
                {
                    if (MinPlayers.Equals(null))
                    {
                        result = "Pole nie może być puste!";
                    }
                    else if (MinPlayers > MaxPlayers)
                    {
                        result = "Min Graczy nie może być więcej niż Max Graczy";
                    }
                    
                }
                return result;
            }
        }



        #endregion



        #region Constructors

        public GameDetailsViewModel(Game game)
        {
            this.game = game;
            this.Title = game.Title;
            this.MaxPlayers = game.MaxPlayers;
            this.MinPlayers = game.MinPlayers;
            this.MaxPrize = game.MaxPrize;
            this.MinBet = game.MinBet;
        }

        public GameDetailsViewModel()
        {
        }

        #endregion



        #region Methods
        private void OnSave()
        {
            CasinoData.CasinoDataRepository dataRepository = CasinoDataModel.CasinoDataRepository;
            Game gameToSave = new Game()
            {
                Title = Title,
                MaxPlayers = MaxPlayers,
                MinPlayers = MinPlayers,
                MaxPrize = MaxPrize,
                MinBet = MinBet
        };

            switch (Action)
            {
                case Action.ADD:
                    {
                        Task.Run(() => { dataRepository.AddGame(gameToSave); });

                        addDelegate(gameToSave);

                        break;
                    }
                case Action.EDIT:
                    {
                        Task.Run(() => { dataRepository.UpdateGame(game, gameToSave); });
                        editDelegate(gameToSave);

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
