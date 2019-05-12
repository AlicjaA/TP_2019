using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    class Event
    {
        private CurrentGame currentGame;
        private User user;
        private DateTimeOffset startGameTime;
        private DateTimeOffset endGameTime;

        public CurrentGame CurrentGame
        {
            get => currentGame;
            set => currentGame = value;
        }

        public User User
        {
            get => user;
            set => user = value;
        }

        public DateTimeOffset StartGameTime
        {
            get => startGameTime;
            set => startGameTime = value;
        }

        public DateTimeOffset EndGameTime
        {
            get => endGameTime;
            set => endGameTime = value;
        }





    }
}
