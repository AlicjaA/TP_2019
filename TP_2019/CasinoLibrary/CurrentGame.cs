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
            get => game;
            set => game = value;
        }

        [DataMember()]
        public int ID
        {
            get => id;
            set => id = value;
        }

        [DataMember()]
        public int HowManyPlayers
        {
            get => howManyPlayers;
            set => howManyPlayers = value;
        }

        [DataMember()]
        public double CurrentPrize
        {
            get => currentPrize;
            set => currentPrize = value;
        }

        [DataMember()]
        public double CurrentBet
        {
            get => currentBet;
            set => currentBet = value;
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
