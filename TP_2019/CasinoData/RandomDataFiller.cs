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
            string title = "Title";
          
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

            // fill games container with random objects
            //int id, string title, int maxPlayers, int minPlayers, double maxPrize, double minBet
            for (int i = 0; i < numberOfGames; i++)
            {
                 int id = i;
                games.Add(id, new Game()
                {
                    ID=i,
                    Title = title + i,
                    MinPlayers=i,
                    MaxPlayers = i+10,
                    MaxPrize = i+100,
                    MinBet = i
                    
                });
            }

            // fill currentGames container with random objects
            //int id, Game game, int howManyPlayers, double currentPrize, double currentBet, DateTimeOffset startGameTime, DateTimeOffset endGameTime
            for (int i = 0; i < numberOfCurrentGames; i++)
            {
                currentGames.Add(new CurrentGame
                {
                    ID = i,
                    Game = context.games[rnd.Next(0, numberOfGames)],
                    HowManyPlayers = i+2,
                    CurrentPrize = i+100,
                    CurrentBet = i,
                    StartGameTime = new DateTimeOffset(DateTime.Now, new TimeSpan())
                });
            }

            // fill events container with random objects
            //CurrentGame currentGame, User user, DateTimeOffset startGameTime
            for (int i = 0; i < numberOfEvents; i++)
            {
                events.Add(new Event
                {
                    CurrentGame = context.currentGames[rnd.Next(0, numberOfCurrentGames)],
                    User = context.users[rnd.Next(0, numberOfUsers)],
                    StartGameTime = new DateTimeOffset(DateTime.Now, new TimeSpan())

                });
            }


    }
    }
}
