using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.XmlObjectSerializer;

namespace CasinoDataModelLibrary
{
    [DataContract()]
    [Serializable]
    public class Event : INotifyPropertyChanged
    {
        private CurrentGame currentGame;
        private User user;
        private DateTimeOffset startGameTime;
        private DateTimeOffset endGameTime;


        [DataMember()]
        public int ID { get; set; }

        [DataMember()]
        public CurrentGame CurrentGame
        {
            get { return currentGame; }
            set { currentGame = value;
                OnPropertyChanged("CurrentGame"); }
        }

        [DataMember()]
        public User User
        {
            get { return user; }
            set { user = value;
                OnPropertyChanged("User"); }
        }

        [DataMember()]
        public DateTimeOffset StartGameTime
        {
            get { return startGameTime; }
            set { startGameTime = value;
                OnPropertyChanged("StartGameTime"); }
        }

        [DataMember()]
        public DateTimeOffset EndGameTime
        {
            get { return endGameTime; }
            set { endGameTime = value;
                OnPropertyChanged("EndGameTime"); }
        }

        public override string ToString()
        {
            string str = "Gra rozpoczęta przez: \n" + User + "\n" + CurrentGame + "\nCzas rozpoczęcia gry " + startGameTime + "\nCzas zakończenia gry " + endGameTime;
            return str;
        }
        
        

        public Event (User user, CurrentGame currentGame, DateTimeOffset startGameTime, DateTimeOffset endGameTime)
        {
            this.user = user;
            this.currentGame = currentGame;
            this.startGameTime = startGameTime;
            this.endGameTime = endGameTime;
        }

        public override bool Equals(object obj)
        {
            var otherEvent = obj as Event;
            return otherEvent != null && 
                   currentGame == otherEvent.currentGame && 
                   user == otherEvent.user && 
                   startGameTime == otherEvent.startGameTime && 
                   endGameTime == otherEvent.endGameTime;
        }

        public Event() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*
        public override int GetHashCode()
        {
            var hashCode = 352033288;
            hashCode = hashCode * -1521134295 + EqualityComparer<CurrentGame>.Default.GetHashCode(currentGame);
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(user);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(startGameTime);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(endGameTime);
            return hashCode;
        }
        */


    }
}
