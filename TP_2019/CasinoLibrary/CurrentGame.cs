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
        private DateTime startGameTime;
        private DateTime endGameTime;




        [DataMember()]
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

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
        public DateTime StartGameTime
        {
            get { return startGameTime; }
            set
            {
                startGameTime = value;
                OnPropertyChanged("StartGameTime");
            }
        }

        [DataMember()]
        public DateTime EndGameTime
        {
            get { return endGameTime; }
            set
            {
                endGameTime = value;
                OnPropertyChanged("EndGameTime");
            }
        }


        public CurrentGame(int id)
        {
            this.ID = id;
        }

        public CurrentGame(int id, Game game)
        {
            this.ID = id;
            this.game = game;
        }

        public CurrentGame(int id, Game game, int howManyPlayers)
        {
            this.ID = id;
            this.game = game;
            this.howManyPlayers = howManyPlayers;
        }

        public CurrentGame(int id, Game game, int howManyPlayers, double currentPrize)
        {
            this.ID = id;
            this.game = game;
            this.howManyPlayers = howManyPlayers;
            this.currentPrize = currentPrize;
        }

        public CurrentGame(int id, Game game, int howManyPlayers, double currentPrize, double currentBet)
        {
            this.ID = id;
            this.game = game;
            this.howManyPlayers = howManyPlayers;
            this.currentPrize = currentPrize;
            this.currentBet = currentBet;
        }

        public CurrentGame(int id, Game game, int howManyPlayers, double currentPrize, double currentBet, DateTime startGameTime)
        {
            this.ID = id;
            this.game = game;
            this.howManyPlayers = howManyPlayers;
            this.currentPrize = currentPrize;
            this.currentBet = currentBet;
            this.startGameTime = startGameTime;
        }

        public CurrentGame(int id, Game game, int howManyPlayers, double currentPrize, double currentBet, DateTime startGameTime, DateTime endGameTime)
        {
            this.ID = id;
            this.game = game;
            this.howManyPlayers = howManyPlayers;
            this.currentPrize = currentPrize;
            this.currentBet = currentBet;
            this.startGameTime = startGameTime;
            this.endGameTime = endGameTime;
        }

        public CurrentGame(int id, Game game, DateTime startGameTime)
        {
            this.ID = id;
            this.game = game;
            this.startGameTime = startGameTime;
        }

        public CurrentGame() { }



        public override string ToString()
        {
            string str = "Current Game:" + "ID" + id + " " + game + "; Number of players: " + howManyPlayers + "; Current prize: " + currentPrize + "; Current bet " + currentBet + "; Game start: " + startGameTime + "; Game end: " + endGameTime + "\n";
            return str;
        }

        public override bool Equals(object obj)
        {
            var otherCurrentGame = obj as CurrentGame;
            return otherCurrentGame != null &&
                   game.Equals(otherCurrentGame.game) &&
                   howManyPlayers.Equals(otherCurrentGame.howManyPlayers) &&
                   currentPrize.Equals(otherCurrentGame.currentPrize) &&
                   currentBet.Equals(otherCurrentGame.currentBet) &&
                   startGameTime.Equals(otherCurrentGame.startGameTime) &&
                   endGameTime.Equals(otherCurrentGame.endGameTime);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public override int GetHashCode()
        {
            var hashCode = 352033288;
            hashCode = hashCode * -1521134295 + EqualityComparer<Game>.Default.GetHashCode(game);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(howManyPlayers);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(currentPrize);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(currentBet);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime>.Default.GetHashCode(startGameTime);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime>.Default.GetHashCode(endGameTime);
            return hashCode;
        }



    }
}
