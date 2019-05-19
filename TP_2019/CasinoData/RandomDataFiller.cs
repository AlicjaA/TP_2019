using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public class RandomDataFiller : DataFiller
    {
        private int numberOfGames;
        private int numberOfCurrentGames;
        private int numberOfUsers;
        private int numberOfEvents;

        public int NumberOfGames
        {
            get => numberOfGames;
            set => numberOfGames = value;
        }

        public int NumberOfCurrentGames
        {
            get => numberOfCurrentGames;
            set => numberOfCurrentGames = value;
        }

        public int NumberOfUsers
        {
            get => numberOfUsers;
            set => numberOfUsers = value;
        }

        public int NumberOfEvents
        {
            get => numberOfEvents;
            set => numberOfEvents = value;
        }



        public override void Fill(ref DataContext context)
        {
            


        }
    }
}
