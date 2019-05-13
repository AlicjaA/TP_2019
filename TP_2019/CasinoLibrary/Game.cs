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
        private String name;
        private int maxPlayers;
        private int minPlayers;
        private Double maxPrize;
        private Double minBet;

        public Game(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id => id;

        public string Name => name;

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

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
