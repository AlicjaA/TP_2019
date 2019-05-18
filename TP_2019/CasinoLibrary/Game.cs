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
        private String title;
        private int maxPlayers;
        private int minPlayers;
        private Double maxPrize;
        private Double minBet;

        public Game(int id, string name)
        {
            this.id = id;
            this.title = name;
        }

        public Game(int id, string title, int maxPlayers, int minPlayers, double maxPrize, double minBet)
        {
            this.id = id;
            this.title = title;
            this.maxPlayers = maxPlayers;
            this.minPlayers = minPlayers;
            this.maxPrize = maxPrize;
            this.minBet = minBet;
        }

        public Game()
        {

        }

        public int ID       //Id => id;
        {
            get => id;
            set => id = value;
        }


        public string Title //=> name;
        {
            get => title;
            set => title = value;
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
