using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    public class CurrentGame
    {
        private int id;
        private Game game;
        private int howManyPlayers;
        private Double currentPrize;
        private Double currentBet;
        private DateTimeOffset startGameTime;
        private DateTimeOffset? endGameTime;

        

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

        public CurrentGame()
        {
            throw new NotImplementedException();
        }

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
            set => endGameTime = value;
        }

        public Game Game { get; set; }
    }
}
