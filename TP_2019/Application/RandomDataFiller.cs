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



        public override void Fill(ref DataContext context)
        {
            var users = context.users;
            var games = context.games;
            var events = context.events;
            var currentGames = context.currentGames;


            
            string name = "Name";
            string surname = "Surname";
            string title = "Title";
            int id ;
            int minPlayers;
            int maxPlayers;
            double maxPrize;
            double minBet;
            DateTime start = new DateTime(year: 2010, month: 1, day: 1);
            DateTime end = new DateTime(year: 2019, month: 12, day: 31);
            int rangeForStartGame = (end - start).Days;
            int rangeForEndGame = (DateTime.Today - end.AddDays(1)).Days;

            Random rnd = new Random();

            //fill users container with random objects
            for (int i = 0; i < numberOfUsers; i++)
            {
                users.Add(new User()
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
            //int id, string title, int maxPlayers, int minPlayers, double maxPrize, double minBet
            for (int i = 0; i < numberOfGames; i++)
            {
                id = i;
                games.Add(id, new Game()
                {
                    ID=id,
                    Title = title + i,
                    MinPlayers = i,
                    MaxPlayers = i,
                    MaxPrize = i + 1000.0,
                    MinBet = i + 10.0
                    
                });
            }

            // fill currentGames container with random objects
            //int id, Game game, int howManyPlayers, double currentPrize, double currentBet, DateTimeOffset startGameTime, DateTimeOffset endGameTime
            for (int i = 0; i < numberOfCurrentGames; i++)
            {
                currentGames.Add(new CurrentGame
                {   
                    // generates random date between 01.01.2010 and 31.12.2019
                    StartGameTime = start.AddDays(rnd.Next(rangeForStartGame)),
                    // gets game from dictionary by random id number
                    Game = context.games[rnd.Next(0, numberOfGames)]
                });
                /*
                {
                    ID = i,
                    Game = context.games[rnd.Next(0, numberOfGames)],
                    HowManyPlayers = i+2,
                    CurrentPrize = i+100,
                    CurrentBet = i,
                    StartGameTime = new DateTimeOffset(2019, 1, 21, 00, 00, 00, new TimeSpan(1, 0, 0))
                });
                */
            }

            // fill events container with random objects
            //CurrentGame currentGame, User user, DateTimeOffset startGameTime
            for (int i = 0; i < numberOfEvents; i++)
            {
                events.Add(new Event
                {
                    CurrentGame = context.currentGames[rnd.Next(0, numberOfCurrentGames)],
                    User = context.users[rnd.Next(0, numberOfUsers)],
                    StartGameTime = end.AddDays(rnd.Next(rangeForEndGame))  //new DateTimeOffset(2019, 1, 21, 00, 00, 00, new TimeSpan(1, 0, 0))

                });
            }

        }

    }
}
