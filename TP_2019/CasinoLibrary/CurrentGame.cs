using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    [DataContract()]
    [Serializable]
    public class CurrentGame : INotifyPropertyChanged
    {
        private int id;
        private Game game;
        private int howManyPlayers;
        private Double currentPrize;
        private Double currentBet;
        private DateTimeOffset startGameTime;
        private DateTimeOffset endGameTime;

        
        [DataMember()]
        public Game Game
        {
            get { return game; }
            set
            {
                game = value;
                OnPropertyChanged("Game");
            }
        }

        [DataMember()]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember()]
        public int HowManyPlayers
        {
            get { return howManyPlayers; }
            set
            {
                howManyPlayers = value;
                OnPropertyChanged("HowManyPlayers");
            }
        }

        [DataMember()]
        public double CurrentPrize
        {
            get { return currentPrize; }
            set
            {
                currentPrize = value;
                OnPropertyChanged("CurrentPrize");

            }
        }

        [DataMember()]
        public double CurrentBet
        {
            get { return currentBet; }
            set
            {
                currentBet = value;
                OnPropertyChanged("CurrentBet");
            }
        }

        [DataMember()]
        public DateTimeOffset StartGameTime
        {
            get { return startGameTime; }
            set
            {
                startGameTime = value;
                OnPropertyChanged("StartGameTime");
            }
    }

        [DataMember()]
        public DateTimeOffset EndGameTime
        {
            get { return endGameTime; }
            set
            {
                endGameTime = value;
                OnPropertyChanged("EndGameTime");
            }
        }

       

        public override string ToString()
        {
            string str = "Current Game:" + "ID" + id + " " + game + "; Number of players: " + howManyPlayers + "; Current prize: " + currentPrize + "; Current bet " + currentBet + "; Game start: " + startGameTime + "; Game end: " + endGameTime + "\n";
            return str;
        }

        public override bool Equals(object obj)
        {
            var otherCurrentGame = obj as CurrentGame;
            return otherCurrentGame != null && 
                   game == otherCurrentGame.game &&
                   howManyPlayers == otherCurrentGame.howManyPlayers && 
                   currentPrize == otherCurrentGame.currentPrize &&
                   currentBet == otherCurrentGame.currentBet &&  
                   startGameTime == otherCurrentGame.startGameTime &&
                   endGameTime == otherCurrentGame.endGameTime;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*
        public override int GetHashCode()
        {
            var hashCode = 352033288;
            hashCode = hashCode * -1521134295 + EqualityComparer<Game>.Default.GetHashCode(game);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(howManyPlayers);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(currentPrize);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(currentBet);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(startGameTime);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(endGameTime);
            return hashCode;
        }
        */
        

    }
}
