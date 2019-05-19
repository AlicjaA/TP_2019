using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;

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
            var users = context.users;
            var games = context.games;
            var events = context.events;
            var currentGames = context.currentGames;


            
            string name = "Name";
            string surname = "Surname";
          
            Random rnd = new Random();

            //fill users container with random objects
            for (int i = 0; i < numberOfUsers; i++)
            {
                
                users.Add( new User()
                {
                    ID=i.ToString(),
                    Age = i,
                    FirstName = name + i,
                    LastName = surname + i,
                    //creates 9 digit random number
                    Telephone = rnd.Next(100000000, 999999999).ToString()
                });
            }


        }
    }
}
