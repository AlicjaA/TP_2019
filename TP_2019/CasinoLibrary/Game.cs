using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    class Game
    {
        private int id;
        private int maxPlayers;
        private int minPlayers;
        private Double maxPrize;
        private Double minBet;

        public int IdG
        {
            get => id;
            set => id = value;
        }

        public double MaxPrize
        {
            get => maxPrize;
            set => maxPrize = value;
        }

        public int MaxPlayers
        {
            get => maxPlayers;
            set => maxPlayers = value;
        }

        public int MinPlayers
        {
            get => minPlayers;
            set => minPlayers = value;
        }

        public double MinBet
        {
            get => minBet;
            set => minBet = value;
        }
    }
}
