using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    class CurrentGame
    {
        private int id;
        private Game game_id;
        private int howManyPlayers;
        private Double currentPrize;
        private Double currentBet;
        private DateTimeOffset startTime;
        private DateTimeOffset? endTime;

        public CurrentGame(int id, Game gameId, DateTimeOffset startTime)
        {
            this.id = id;
            game_id = gameId;
            this.startTime = startTime;
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

        public DateTimeOffset EndTime
        {
            set => endTime = value;
        }
    }
}
