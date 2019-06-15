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
    public class EventDetailsViewModel : Collective.ViewModel, INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields

        private Action<object> addDelegate;
        private Action<object> editDelegate;
        private Action<object> closeDelegate;
        private Action<object> showDelegate;
        public event PropertyChangedEventHandler PropertyChanged;

        private List<User> users;
        private List<CurrentGame> currentGames;
        Event ev;
        private int id;
        private CurrentGame currentGame;
        private User user;
        private DateTime startGameTime = DateTime.Now;
        private DateTime endGameTime = DateTime.Now;
        private ICommand saveCommand;
        private ICommand cancelCommand;

        #endregion

        #region EventDataDefinitionsGetters&Setters

        public int ID
        {
            get => id;
            set => id = value;
        }

        public List<User> Users
        {
            get
            {
                users = CasinoDataModel.CasinoDataRepository.GetAllUsers().ToList(); ;
                return users;
            }
        }

        public List<CurrentGame> CurrentGames
        {
            get
            {
                currentGames = CasinoDataModel.CasinoDataRepository.GetAllCurrentGame().ToList(); ;
                return currentGames;
            }
        }

        public Event Ev
        {
            get => ev;
            set => ev = value;
        }

        public CurrentGame CurrentGame
        {
            get => currentGame;
            set => currentGame = value;
        }

        public User User
        {
            get => user;
            set => user = value;
        }

        public DateTime StartGameTime
        {
            get => startGameTime;
            set => startGameTime = value;
        }

        public DateTime EndGameTime
        {
            get => endGameTime;
            set => endGameTime = value;
        }

        #endregion
       
        #region Error

        public string Error
        {
            get { return String.Empty; }
        }

        public string this[string fieldName]
        {
            get
            {
                string result = null;
                if (fieldName == "User")
                {
                    if (User==null)
                        result = "Pole nie może być puste!";
                }

                if (fieldName == "CurrentGame")
                {
                    if (CurrentGame==null)
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

        public EventDetailsViewModel(Event ev, User user, CurrentGame currentGame)
        {
            this.ev = ev;
            this.User = user;
            this.CurrentGame = currentGame;
            this.StartGameTime = ev.StartGameTime;
            this.EndGameTime = ev.EndGameTime;
        }

        public EventDetailsViewModel()
        {
        }
        #endregion


        #region Methods

        private void OnSave()
        {
            CasinoData.CasinoDataRepository dataRepository = CasinoDataModel.CasinoDataRepository;
            Event eventToSave = new Event()
            {
                User = User,
                CurrentGame = CurrentGame,
                StartGameTime = StartGameTime,
                EndGameTime = EndGameTime
            };

            switch (Action)
            {
                case Action.ADD:
                    {
                        Task.Run(() => { dataRepository.AddEvent(eventToSave); });

                        addDelegate(eventToSave);

                        break;
                    }
                case Action.EDIT:
                    {
                        Task.Run(() =>
                        {
                            dataRepository.UpdateEvents(ev, eventToSave);
                        });
                        editDelegate(eventToSave);

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

    

