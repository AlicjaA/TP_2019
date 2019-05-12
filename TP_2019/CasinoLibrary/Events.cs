using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    class Events
    {
        private CurrentGame currentGame;
        private User user;
        private DataTimeOffset startGameTime;
        private DateTimeOffset endGameTime;  //przy deklaracj zmiennej ? pole moze miec wartosc null


        public CurrentGame CurrentGame
        {
            get => currentGame;
            set => currentGame => value;
        }

        public User User
        {
            get => user;
            set => user => value;
        }

        public DateTimeOffset startGameTime;
        {        
            get => startGameTime;
            set => startGameTime => value;
        }


    }
}
