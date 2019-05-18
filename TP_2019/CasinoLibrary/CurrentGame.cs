using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    [Serializable]
    public class CurrentGame
    {
        private int id;
        private Game game;
        private int howManyPlayers;
        private Double currentPrize;
        private Double currentBet;
        private DateTimeOffset startGameTime;
        private DateTimeOffset endGameTime;

        

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

        public CurrentGame(int id, Game game, int howManyPlayers, double currentPrize, double currentBet, DateTimeOffset startGameTime)
        {
            this.ID = id;
            this.game = game;
            this.howManyPlayers = howManyPlayers;
            this.currentPrize = currentPrize;
            this.currentBet = currentBet;
            this.startGameTime = startGameTime;
        }

        public CurrentGame(int id, Game game, int howManyPlayers, double currentPrize, double currentBet, DateTimeOffset startGameTime, DateTimeOffset endGameTime)
        {
            this.ID = id;
            this.game = game;
            this.howManyPlayers = howManyPlayers;
            this.currentPrize = currentPrize;
            this.currentBet = currentBet;
            this.startGameTime = startGameTime;
            this.endGameTime = endGameTime;
        }

        public CurrentGame(int id, Game game, DateTimeOffset startGameTime)
        {
            this.ID = id;
            this.game = game;
            this.startGameTime = startGameTime;
        }

        public CurrentGame() { }

        public int ID
        {
            get => id;
            set => id = value;
        }

        public int HowManyPlayers
        {
            get => howManyPlayers;
            set => howManyPlayers = value;
        }

        public double CurrentPrize
        {
            get => currentPrize;
            set => currentPrize = value;
        }

        public double CurrentBet
        {
            get => currentBet;
            set => currentBet = value;
        }

        public DateTimeOffset StartGameTime
        {
            get => startGameTime;
            set => startGameTime = value;
        }

        public DateTimeOffset? EndGameTime
        {
            get => endGameTime;
            set => endGameTime = (DateTimeOffset) value;
        }

        //public Game Game { get; set; }

        public override string ToString()
        {
            string str = "Current Game:" + "ID" + id + "; Game " + game + "; Number of players: " + howManyPlayers + "; Current prize: " + currentPrize + "; Current bet " + currentBet + "; Game start: " + startGameTime + "; Game end: " + endGameTime + "\n";
            return str;
        }

        public override bool Equals(object obj)
        {
            if (obj is CurrentGame)
            {
                var otherGame = (CurrentGame)obj;
                return id.Equals(otherGame.id) && game.Equals(otherGame.game) &&
                       howManyPlayers.Equals(otherGame.howManyPlayers) && currentPrize.Equals(otherGame.currentPrize) &&
                       currentBet.Equals(otherGame.currentBet) && startGameTime.Equals(otherGame.startGameTime) &&
                       endGameTime.Equals(otherGame.endGameTime);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            var hashCode = 352033288;
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Game>.Default.GetHashCode(game);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(howManyPlayers);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(currentPrize);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(currentBet);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(startGameTime);
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTimeOffset>.Default.GetHashCode(endGameTime);
            return hashCode;
        }




    }
}
