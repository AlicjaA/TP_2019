using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    public class Game
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

        public Game()
        {
            throw new NotImplementedException();
        }

        public int ID       //Id => id;
        {
            get => id;
            set => id = value;
        }


        public string Name //=> name;
        {
            get => name;
            set => name = value;
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
