﻿using System;
using CasinoData;
using CasinoDataModelLibrary;

namespace Application
{
    public class ConstDataFiller : DataFiller
    {
        public override void Fill(ref DataContext context)
        {
            var user = context.users;
            var games = context.games;
            var events = context.events;
            var currentGame = context.currentGames;

            // create users object
            User user0 = new User()
            {
                ID = 000,
                FirstName = "Admin",
                LastName = "Master",
                Telephone = "000000000",
                Age = 20
            };
            User user1 = new User()
            {
                ID = 001,
                FirstName = "AAAAAAA",
                LastName = "BBBBBBB",
                Telephone = "111111111",
                Age = 21
            };
            User user2 = new User()
            {
                ID = 002,
                FirstName = "CCCCCCC",
                LastName = "DDDDDDD",
                Telephone = "222222222",
                Age = 22
            };
            User user3 = new User()
            {
                ID = 003,
                FirstName = "EEEEEEE",
                LastName = "FFFFFFF",
                Telephone = "333333333",
                Age = 23
            };
            User user4 = new User()
            {
                ID = 004,
                FirstName = "GGGGGGG",
                LastName = "HHHHHHH",
                Telephone = "444444444",
                Age = 24
            };


            // intialize users list
            user.Add(user0);
            user.Add(user1);
            user.Add(user2);
            user.Add(user3);
            user.Add(user4);

           
            
            // create games object
            Game game0 = new Game()
            {
                ID = 000,
                Title = "FifteenPuzzle",
                MaxPlayers = 1,
                MinPlayers = 1,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };
            Game game1 = new Game()
            {
                ID = 001,
                Title = "Poker",
                MaxPlayers = 10,
                MinPlayers = 2,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };
            Game game2 = new Game()
            {
                ID = 002,
                Title = "PokerNoLimit",
                MaxPlayers = 10,
                MinPlayers = 2,
                MaxPrize = 100000000000.0,
                MinBet = 100000.0
            };
            Game game3 = new Game()
            {
                ID = 003,
                Title = "Texas Hold’em",
                MaxPlayers = 10,
                MinPlayers = 2,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };
            Game game4 = new Game()
            {
                ID = 004,
                Title = "DrawPoker",         //poker dobierany
                MaxPlayers = 10,
                MinPlayers = 2,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };
            Game game5 = new Game()
            {
                ID = 005,
                Title = "BlackJack",
                MaxPlayers = 10,
                MinPlayers = 2,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };
            Game game6 = new Game()
            {
                ID = 006,
                Title = "Ruletka",
                MaxPlayers = 99,
                MinPlayers = 1,
                MaxPrize = 100000.0,
                MinBet = 5.0
            };

            // initialize games dictionary
            context.games.Add(game0.ID, game0);
            context.games.Add(game1.ID, game1);
            context.games.Add(game2.ID, game2);
            context.games.Add(game3.ID, game3);
            context.games.Add(game4.ID, game4);
            context.games.Add(game5.ID, game5);
            context.games.Add(game6.ID, game6);

            // create current games

            CurrentGame currentGame0 = new CurrentGame
            {
                ID = 000,
                Game = game0,
                CurrentBet = 1000.0,
                CurrentPrize = 100000.0,
                HowManyPlayers = 1,
                StartGameTime = new DateTimeOffset(2019, 1, 01, 00, 00, 00, new TimeSpan(1, 0, 0)),
                };

            CurrentGame currentGame1 = new CurrentGame
            {
                ID = 001,
                Game = game1,
                CurrentBet = 100.0,
                CurrentPrize = 10000.0,
                HowManyPlayers = 2,
                StartGameTime = new DateTimeOffset(2019, 1, 01, 00, 00, 00, new TimeSpan(1, 0, 0)),
            };

            CurrentGame currentGame2 = new CurrentGame
            {
                ID = 002,
                Game = game2,
                CurrentBet = 100.0,
                CurrentPrize = 100000.0,
                HowManyPlayers = 3,
                StartGameTime = new DateTimeOffset(2019, 1, 01, 00, 00, 00, new TimeSpan(1, 0, 0)),
            };

            CurrentGame currentGame3 = new CurrentGame
            {
                ID = 003,
                Game = game3,
                CurrentBet = 100.0,
                CurrentPrize = 10000.0,
                HowManyPlayers = 4,
                StartGameTime = new DateTimeOffset(2019, 1, 01, 00, 00, 00, new TimeSpan(1, 0, 0)),
            };

            CurrentGame currentGame4 = new CurrentGame
            {
                ID = 004,
                Game = game4,
                CurrentBet = 100.0,
                CurrentPrize = 10000.0,
                HowManyPlayers = 2,
                StartGameTime = new DateTimeOffset(2019, 1, 01, 00, 00, 00, new TimeSpan(1, 0, 0)),
            };
            // itd......



            // initialize current games
            currentGame.Add(currentGame0);
            currentGame.Add(currentGame1);
            currentGame.Add(currentGame2);
            currentGame.Add(currentGame3);
            currentGame.Add(currentGame4);

            // itd......


            Event event0 = new Event()
            {
                CurrentGame = currentGame0,
                User = user0,
                StartGameTime = new DateTimeOffset(2019, 1, 01, 00, 00, 00, new TimeSpan(1, 0, 0)),
                //EndGameTime = new DateTimeOffset(2019, 1, 21, 00, 00, 00, new TimeSpan(1, 0, 0)),
            };

            Event event1 = new Event()
            {
                CurrentGame = currentGame0,
                User = user1,
                StartGameTime = new DateTimeOffset(2019, 1, 01, 00, 00, 00, new TimeSpan(1, 0, 0)),
                //EndGameTime = new DateTimeOffset(2019, 1, 21, 00, 00, 00, new TimeSpan(1, 0, 0)),
            };

            Event event2 = new Event()
            {
                CurrentGame = currentGame0,
                User = user2,
                StartGameTime = new DateTimeOffset(2019, 1, 01, 00, 00, 00, new TimeSpan(1, 0, 0)),
                //EndGameTime = new DateTimeOffset(2019, 1, 21, 00, 00, 00, new TimeSpan(1, 0, 0)),
            };

            Event event3 = new Event()
            {
                CurrentGame = currentGame1,
                User = user3,
                StartGameTime = new DateTimeOffset(2019, 1, 01, 00, 00, 00, new TimeSpan(1, 0, 0)),
                //EndGameTime = new DateTimeOffset(2019, 1, 21, 00, 00, 00, new TimeSpan(1, 0, 0)),
            };

            Event event4 = new Event()
            {
                CurrentGame = currentGame1,
                User = user4,
                StartGameTime = new DateTimeOffset(2019, 1, 01, 00, 00, 00, new TimeSpan(1, 0, 0)),
                //EndGameTime = new DateTimeOffset(2019, 1, 21, 00, 00, 00, new TimeSpan(1, 0, 0)),
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

            
        }
    }
}
