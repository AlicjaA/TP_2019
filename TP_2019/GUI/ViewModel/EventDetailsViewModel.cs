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
        Event ev = new Event();
        private CurrentGame currentGame;
        private User user;
        private DateTimeOffset startGameTime;
        private DateTimeOffset endGameTime;
        private ICommand saveCommand;
        private ICommand cancelCommand;

        #endregion

        #region EventDataDefinitionsGetters&Setters

        public List<User> Users
        {
            get => users;
            set => users = value;
        }

        public List<CurrentGame> CurrentGames
        {
            get => currentGames;
            set => currentGames = value;
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
                    if (User.Equals(null))
                        result = "Pole nie może być puste!";
                }

                if (fieldName == "CurrentGame")
                {
                    if (CurrentGame.Equals(null))
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


       
    }
}

    

