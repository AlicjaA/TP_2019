using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{   
    //[DataContract()]
    [Serializable]
    public class Game
    {
        private int id;
        private String title;
        private int maxPlayers;
        private int minPlayers;
        private Double maxPrize;
        private Double minBet;

        
        //[DataMember()]
        public int ID //Id => id;
        {
            get => id;
            set => id = value;
        }

        //[DataMember()]
        public string Title //=> name;
        {
            get => title;
            set => title = value;
        }

        //[DataMember()]
        public double MaxPrize
        {
            get => maxPrize;
            set => maxPrize = value;
        }

        //[DataMember()]
        public int MaxPlayers
        {
            get => maxPlayers;
            set => maxPlayers = value;
        }

        //[DataMember()]
        public int MinPlayers
        {
            get => minPlayers;
            set => minPlayers = value;
        }

        //[DataMember()]
        public double MinBet
        {
            get => minBet;
            set => minBet = value;
        }

        public override string ToString()
        {
            string str = "Game: " + " ID " + id + "; Title " + title + "; Max prize: " + maxPrize + "; Min bet: " +
                         minBet + "; Max players: " + maxPlayers + "; Min players: " + minPlayers + "\n";
            return str;
        }

        public override bool Equals(object obj)
        {
            if (obj is Game)
            {
                var otherGame = (Game) obj;
                return id.Equals(otherGame.id) && title.Equals(otherGame.title) &&
                       MaxPrize.Equals(otherGame.MaxPrize) && MinBet.Equals(otherGame.MinBet) &&
                       MaxPlayers.Equals(otherGame.MaxPlayers) && MinPlayers.Equals(otherGame.MinPlayers);
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
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(title);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(maxPrize);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(minBet);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(maxPlayers);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(minPlayers);
            return hashCode;
        }
    }
}