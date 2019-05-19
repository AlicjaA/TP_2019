using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    [Serializable]
    public class Event
    {
        private CurrentGame currentGame;
        private User user;
        private DateTimeOffset startGameTime;
        private DateTimeOffset endGameTime;

        public Event(CurrentGame currentGame, User user, DateTimeOffset startGameTime)
        {
            this.currentGame = currentGame;
            this.user = user;
            this.startGameTime = startGameTime;
        }

        public Event()
        {
            throw new NotImplementedException();
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

        public override string ToString()
        {
            string str = "Gra rozpoczęta przez: \n" + User + "\n" + CurrentGame + "\nCzas rozpoczęcia gry " + startGameTime + "\nCzas zakończenia gry " + endGameTime;
            return str;
        }

        
        public override bool Equals(object obj)
        {
            if (obj is Event)
            {
                var otherEvent = (Event)obj;
                return currentGame.Equals(otherEvent.currentGame) && user.Equals(otherEvent.user) && startGameTime.Equals(otherEvent.startGameTime) && endGameTime.Equals(otherEvent.endGameTime);
            }
            else
            {
                return false;
            }
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

    }
}
