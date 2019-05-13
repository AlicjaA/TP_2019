using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;

namespace CasinoData
{
    public class ConstDataFiller : DataFiller
    {
        public override void Fill(ref DataContext context)
        {
            var user = context.user;
            var games = context.game;
            var events = context.events;
            var currentGame = context.currentGame;

            // create user object
            User user0 = new User()
            {
                ID = 000.ToString(),
                FirstName = "Admin",
                LastName = "Master",
                Telephone = "000000000"
            };
            User user1 = new User()
            {
                ID = 001.ToString(),
                FirstName = "AAAAAAA",
                LastName = "BBBBBBB",
                Telephone = "111111111"
            };
            User user2 = new User()
            {
                ID = 002.ToString(),
                FirstName = "CCCCCCC",
                LastName = "DDDDDDD",
                Telephone = "222222222"
            };
            User user3 = new User()
            {
                ID = 003.ToString(),
                FirstName = "EEEEEEE",
                LastName = "FFFFFFF",
                Telephone = "333333333"
            };
            User user4 = new User()
            {
                ID = 004.ToString(),
                FirstName = "GGGGGGG",
                LastName = "HHHHHHH",
                Telephone = "444444444"
            };


            // intialize user list
            user.Add(user0);
            user.Add(user1);
            user.Add(user2);
            user.Add(user3);

           
            
            // create game object
            Game game0 = new Game()
            {
                ID = 000,
                Name = "FifteenPuzzle",
                MaxPlayers = 1,
                MinPlayers = 1,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };
            Game game1 = new Game()
            {
                ID = 001,
                Name = "Poker",
                MaxPlayers = 10,
                MinPlayers = 2,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };
            Game game2 = new Game()
            {
                ID = 002,
                Name = "PokerNoLimit",
                MaxPlayers = 10,
                MinPlayers = 2,
                MaxPrize = 100000000000.0,
                MinBet = 100000.0
            };
            Game game3 = new Game()
            {
                ID = 003,
                Name = "Texas Hold’em",
                MaxPlayers = 10,
                MinPlayers = 2,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };
            Game game4 = new Game()
            {
                ID = 004,
                Name = "DrawPoker",         //poker dobierany
                MaxPlayers = 10,
                MinPlayers = 2,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };
            Game game5 = new Game()
            {
                ID = 005,
                Name = "BlackJack",
                MaxPlayers = 10,
                MinPlayers = 2,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };
            Game game6 = new Game()
            {
                ID = 006,
                Name = "Ruletka",
                MaxPlayers = 99,
                MinPlayers = 1,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };

            // initialize game dictionary
            context.game.Add(game0.ID.ToString(), game0);
            context.game.Add(game1.ID.ToString(), game1);
            context.game.Add(game2.ID.ToString(), game2);
            context.game.Add(game3.ID.ToString(), game3);
            context.game.Add(game4.ID.ToString(), game4);
            context.game.Add(game5.ID.ToString(), game5);
            context.game.Add(game6.ID.ToString(), game6);



            // TODO : create current game

            CurrentGame currentGame0 = new CurrentGame()
            {
                ID = 000,
                CurrentBet = 1000.0,
                CurrentPrize = 100000.0,
                HowManyPlayers = 3,
                StartGameTime = new DateTimeOffset(DateTime.Now, new TimeSpan()),
                EndGameTime = new DateTimeOffset()

            };

            CurrentGame currentGame1 = new CurrentGame()
            {
                ID = 001,
                CurrentBet = 100.0,
                CurrentPrize = 10000.0,
                HowManyPlayers = 2,
                StartGameTime = new DateTimeOffset(DateTime.Now, new TimeSpan()),
                EndGameTime = new DateTimeOffset()

            };

            // itd......



            // initialize current game
            currentGame.Add(currentGame0);
            currentGame.Add(currentGame1);

            // itd......



            // TODO: create events 

            Event event0 = new Event()
            {
                CurrentGame = currentGame0,
                User = user0,
                StartGameTime = DateTimeOffset.Now,
                EndGameTime = null
            };

            Event event1 = new Event()
            {
                CurrentGame = currentGame0,
                User = user1,
                StartGameTime = DateTimeOffset.Now,
                EndGameTime = null
            };

            Event event2 = new Event()
            {
                CurrentGame = currentGame0,
                User = user2,
                StartGameTime = DateTimeOffset.Now,
                EndGameTime = null
            };

            Event event3 = new Event()
            {
                CurrentGame = currentGame1,
                User = user3,
                StartGameTime = DateTimeOffset.Now,
                EndGameTime = null
            };

            Event event4 = new Event()
            {
                CurrentGame = currentGame1,
                User = user4,
                StartGameTime = DateTimeOffset.Now,
                EndGameTime = null
            };
            // itd......





            // initialize events collection
            events.Add(event0);
            events.Add(event1);
            events.Add(event2);
            events.Add(event3);
            events.Add(event4);
            
            
            // itd......
            // itd......





            throw new NotImplementedException();
        }
    }
}
