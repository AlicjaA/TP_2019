using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    //[DataContract()]
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

        

        //[DataMember()]
        public int ID
        {
            get => id;
            set => id = value;
        }

        //[DataMember()]
        public int HowManyPlayers
        {
            get => howManyPlayers;
            set => howManyPlayers = value;
        }

        //[DataMember()]
        public double CurrentPrize
        {
            get => currentPrize;
            set => currentPrize = value;
        }

        //[DataMember()]
        public double CurrentBet
        {
            get => currentBet;
            set => currentBet = value;
        }

        //[DataMember()]
        public DateTimeOffset StartGameTime
        {
            get => startGameTime;
            set => startGameTime = value;
        }

        //[DataMember()]
        public DateTimeOffset EndGameTime
        {
            get => endGameTime;
            set => endGameTime = value;
        }

        //[DataMember()]
        public Game Game { get; set; }

        public override string ToString()
        {
            string str = "Current Game:" + "ID" + id + " " + game + "; Number of players: " + howManyPlayers + "; Current prize: " + currentPrize + "; Current bet " + currentBet + "; Game start: " + startGameTime + "; Game end: " + endGameTime + "\n";
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
