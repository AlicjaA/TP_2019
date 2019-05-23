using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoData;
using CasinoDataModelLibrary;

namespace Application
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

        private DataContext dataContext;

        public override void Fill(ref DataContext context)
        {
            dataContext = context;

            string name = "Name";
            string surname = "Surname";
            string title = "Title";
            int id = 500;
            int minPlayers = 2;
            int maxPlayers = 10;
            double maxPrize = 1000;
            double minBet = 10;

            Random rnd = new Random();

            //fill users container with random objects
            for (int i = 0; i < numberOfUsers; i++)
            {
                dataContext.users.Add(new User()
                {
                    ID=i,
                    Age = i,
                    FirstName = name + i,
                    LastName = surname + i,
                    //creates 9 digit random number
                    Telephone = rnd.Next(100000000, 999999999).ToString()
                });
            }

            // fill games container with random objects
            for (int i = 0; i < numberOfGames; i++)
            {
                id = i;
                dataContext.games.Add(id, new Game()
                {
                    ID=id,
                    Title = title + i,
                    MinPlayers = minPlayers + i,
                    MaxPlayers = maxPlayers + i,
                    MaxPrize = maxPrize + i,
                    MinBet = minBet + i
                    
                });
            }

            // fill currentGames container with random objects
            for (int i = 0; i < numberOfCurrentGames; i++)
            {
                dataContext.currentGames.Add(new CurrentGame
                {
                    ID = i,
                    HowManyPlayers = i + 2,
                    CurrentPrize = i + 100,
                    CurrentBet = i,
                    StartGameTime = DateTimeOffset.Now.AddDays(rnd.Next(1, 2)),
                    // gets game from dictionary by random id number
                    Game = context.games[rnd.Next(0, numberOfGames)]
                });
               
            }

            // fill events container with random objects
            for (int i = 0; i < numberOfEvents; i++)
            {
                dataContext.events.Add(new Event
                {
                    CurrentGame = context.currentGames[rnd.Next(1, numberOfCurrentGames)],
                    User = context.users[rnd.Next(1, numberOfUsers)],
                    StartGameTime = DateTimeOffset.Now.AddDays(rnd.Next(1, 2))

                    //EndGameTime = DateTimeOffset.Now.AddDays(rnd.Next(2, 5))
                    //new DateTimeOffset(2019, 1, 21, 00, 00, 00, new TimeSpan(1, 0, 0))
                });
            }

        }

    }
}
