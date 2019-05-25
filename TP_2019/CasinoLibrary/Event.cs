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
        private int id;
        private CurrentGame currentGame;
        private User user;
        private DateTimeOffset startGameTime;
        private DateTimeOffset endGameTime;


        [DataMember()]
        public int ID
        {
            get => id;
            set => id = value;
        }

        [DataMember()]
        public CurrentGame CurrentGame
        {
            get => currentGame;
            set => currentGame = value;
        }

        [DataMember()]
        public User User
        {
            get => user;
            set => user = value;
        }

        [DataMember()]
        public DateTimeOffset StartGameTime
        {
            get => startGameTime;
            set => startGameTime = value;
        }

        [DataMember()]
        public DateTimeOffset EndGameTime
        {
            get => endGameTime;
            set => endGameTime = value;
        }

        public override string ToString()
        {
            string str = "Gra rozpoczęta przez: \n" + User + "\n" + CurrentGame + "\nCzas rozpoczęcia gry " + startGameTime + "\nCzas zakończenia gry " + endGameTime;
            return str;
        }

        
        public override bool Equals(object obj)
        {
            var otherEvent = obj as Event;
            return otherEvent != null && 
                   currentGame.Equals(otherEvent.currentGame) && 
                   user.Equals(otherEvent.user) && startGameTime.Equals(otherEvent.startGameTime) && 
                   endGameTime.Equals(otherEvent.endGameTime);
        }

        public override int GetHashCode()
        {
            var hashCode = 352033288;
            hashCode = hashCode * -1521134295 + EqualityComparer<CurrentGame>.Default.GetHashCode(currentGame);
            hashCode = hashCode * -1521134295 + EqualityComparer<User>.Default.GetHashCode(user);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(startGameTime);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(endGameTime);
            return hashCode;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
