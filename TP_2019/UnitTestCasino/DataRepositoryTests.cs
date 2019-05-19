using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using CasinoData;
using CasinoDataModelLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCasino
{
    [TestClass]
    public class DataRepositoryTests
    {
        private DataRepository repository;
        private DataContext context;
        private ConstDataFiller dataFiller;
        private CurrentGame CurrentGame;
        private User User;

        [TestInitialize]
        public void TestInitialize()
        {
            dataFiller = new ConstDataFiller();
            context = new DataContext();
            repository = new DataRepository(dataFiller)
            {
                Data = context
            };
            repository.Fill();
        }

        [TestMethod()]
        public void DataRepositoryTest()
        {

        }

        // test for User class _____________________________________________
        [TestMethod()]
        public void AddUserTest()
        {
            int beforeSize = context.users.Count;
            var beforeLastUser = context.users.Last();
            var userToAdd = new User()
            {
                ID = "100",
                Age = 36,
                FirstName = "ABCDEFG",
                LastName = "HIJKLMNOP",
                Telephone = "000000000"
            };
            repository.AddUser(userToAdd);
            int afterSize = context.users.Count;
            var afterLastUser = context.users.Last();

            // check sizes
            Assert.AreNotEqual(beforeSize, afterSize);

            // check if last user aren't equal
            Assert.AreNotEqual(beforeLastUser, afterLastUser);

            // check if the user is on the list
            Assert.IsTrue(context.users.Contains(userToAdd));

        }

        [TestMethod()]
        public void GetUserTest()
        {
            int userIndex = new Random().Next(0, context.users.Count);
            var expectedUser = context.users[userIndex];
            Assert.AreEqual(expectedUser, repository.GetUser(userIndex));
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            var expectedUsers = context.users;
            Assert.AreEqual(expectedUsers, repository.GetAllUsers());
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            int userIndex = context.users.Count - 1;
            var oldUser = repository.GetUser(userIndex);
            var newUser = new User()
            {
                ID = "101",
                Age = 30,
                FirstName = "ALALAL",
                LastName = "LALALAL",
                Telephone = "123456789"
            };
            int beforeSize = context.users.Count;
            repository.UpdateUser(oldUser, newUser);
            int afterSize = context.users.Count;

            var userAfterUpdate = repository.GetUser(userIndex);

            // compare sizes
            Assert.AreEqual(beforeSize, afterSize);

            // compare references (should be different because we only change properties)
            Assert.IsFalse(object.ReferenceEquals(userAfterUpdate, newUser));

            // compare properties
            Assert.AreEqual(newUser.ID, userAfterUpdate.ID);
            Assert.AreEqual(newUser.Age, userAfterUpdate.Age);
            Assert.AreEqual(newUser.FirstName, userAfterUpdate.FirstName);
            Assert.AreEqual(newUser.LastName, userAfterUpdate.LastName);
            Assert.AreEqual(newUser.Telephone, userAfterUpdate.Telephone);
        }


        [TestMethod()]
        public void DeleteUserTest()
        {
            int userIndex = new Random().Next(0, context.users.Count);
            var user = context.users[userIndex];
            Assert.IsTrue(context.users.Contains(user));
            repository.DeleteUser(user);
            Assert.IsFalse(context.users.Contains(user));

        }


        // tests for game class _________________________________________________
        [TestMethod()]
        public void AddGameTest()
        {
            int beforeSize = context.games.Count;
            var beforeLastGame = context.games.Last();
            var gameToAdd = new Game()
            {
                ID = 101,
                Title = "SnakeGame",
                MaxPlayers = 1,
                MinPlayers = 1,
                MaxPrize = 100000,
                MinBet = 10
            };
        }

        [TestMethod()]
        public void GetGameTest()
        {
            var listOfKeys = context.games.Keys;
            foreach (int key in listOfKeys)
            {
                var expectedUser = context.games[key];
                Assert.AreEqual(expectedUser, repository.GetGame(key));
            }
        }

        [TestMethod()]
        public void GetAllGameTest()
        {
            var expectedGames = context.games.Values;
            var actualGames = repository.GetAllGames();
            foreach (Game game in actualGames)
            {
                Assert.IsTrue(expectedGames.Contains(game));
            }
        }

        [TestMethod()]
        public void UpdateGameTest()
        {
            var oldGame = repository.GetGame(101);
            var newGame = new Game()
            {
                ID = 102,
                Title = "SSnake",
                MaxPlayers = 1,
                MinPlayers = 1,
                MaxPrize = 100000,
                MinBet = 100
            };
            int beforeSize = context.games.Count;
            repository.UpdateGame(oldGame, newGame);
            int afterSize = context.games.Count;

            var gameAfterUpdate = context.games[newGame.ID];

            // compare sizes
            Assert.AreEqual(beforeSize, afterSize);

            // compare references (should be different because we only modify properties)
            Assert.IsFalse(object.ReferenceEquals(gameAfterUpdate, newGame));

            // compare games's properties
            Assert.AreEqual(newGame.ID, gameAfterUpdate.ID);
            Assert.AreEqual(newGame.Title, gameAfterUpdate.Title);
            Assert.AreEqual(newGame.MaxPlayers, gameAfterUpdate.MaxPlayers);
            Assert.AreEqual(newGame.MinPlayers, gameAfterUpdate.MinPlayers);
            Assert.AreEqual(newGame.MaxPrize, gameAfterUpdate.MaxPrize);
            Assert.AreEqual(newGame.MinBet, gameAfterUpdate.MinBet);
        }

        [TestMethod()]
        public void DeleteGameTest()
        {
            var game = repository.GetGame(103);
            Assert.IsTrue(context.games.ContainsKey(103));
            repository.DeleteGame(game);
            Assert.IsFalse(context.games.ContainsKey(103));
            Assert.IsFalse(context.games.ContainsValue(game));
        }

        // tests for CurrentGame class ___________________________________________

        [TestMethod()]
        public void AddCurrentGame()
        {
            int beforeSize = context.currentGames.Count;
            var beforeLastCurrentGame = context.currentGames.Last();
            var currentGameToAdd = new CurrentGame()
            {
                StartGameTime = new DateTimeOffset(year: 2019, month: 4, day: 12, hour: 00, minute: 00, second: 00, offset: new TimeSpan(1, 0, 0)),
                EndGameTime = null,
                Game = new Game()

                {
                    ID = 200,
                    Title = "XXXX",
                    MaxPlayers = 10,
                    MinPlayers = 2,
                    MaxPrize = 10000.0,
                    MinBet = 10.0
                }
            };
            repository.AddCurrentGame(currentGameToAdd);
            int afterSize = context.currentGames.Count;
            var afterLastCurrentGame = context.currentGames.Last();

            // check sizes
            Assert.AreNotEqual(beforeSize, afterSize);

            // check if last books aren't equal
            Assert.AreNotEqual(beforeLastCurrentGame, afterLastCurrentGame);

            // check if the book is in the list
            Assert.IsTrue(context.currentGames.Contains(currentGameToAdd));
        }

        [TestMethod()]
        public void GetCurrentGameTest()
        {
            int currentGameIndex = new Random().Next(0, context.currentGames.Count);
            var expectedCurrentGame = context.currentGames[currentGameIndex];
            Assert.AreEqual(expectedCurrentGame, repository.GetCurrentGame(currentGameIndex));
        }

        [TestMethod()]
        public void GetAllCurrentGameTest()
        {
            var expectedCurrentGame = context.currentGames;
            Assert.AreEqual(expectedCurrentGame, repository.GetAllCurrentGames());
        }

        [TestMethod()]
        public void UpdateCurrentGameTest()
        {
            int currentGameIndex = context.currentGames.Count - 1;
            var oldCurrentGame = repository.GetCurrentGame(currentGameIndex);
            var newCurrentGame = new CurrentGame()
            {
                StartGameTime = new DateTimeOffset(year: 2019, month: 10, day: 11, hour: 01, minute: 30, second: 12, offset: new TimeSpan(1, 0, 0)),
                EndGameTime = null,
                Game = new Game()
                {
                    ID = 300,
                    Title = "YYYYY",
                    MaxPlayers = 10,
                    MinPlayers = 2,
                    MaxPrize = 100000.0,
                    MinBet = 10.0
                }
            };
            int beforeSize = context.currentGames.Count;
            repository.UpdateCurrentGame(oldCurrentGame, newCurrentGame);
            int afterSize = context.currentGames.Count;

            var currentGameAfterUpdate = repository.GetCurrentGame(currentGameIndex);

            // compare sizes
            Assert.AreEqual(beforeSize, afterSize);

            // compare references (should be different)
            Assert.IsFalse(object.ReferenceEquals(currentGameAfterUpdate, newCurrentGame));

            // compare properties
            Assert.AreEqual(newCurrentGame.ID, currentGameAfterUpdate.ID);
            Assert.AreEqual(newCurrentGame.Game, currentGameAfterUpdate.Game);
            Assert.AreEqual(newCurrentGame.StartGameTime, currentGameAfterUpdate.StartGameTime);
            Assert.AreEqual(newCurrentGame.EndGameTime, currentGameAfterUpdate.EndGameTime);
            Assert.AreEqual(newCurrentGame.HowManyPlayers, currentGameAfterUpdate.HowManyPlayers);
            Assert.AreEqual(newCurrentGame.CurrentPrize, currentGameAfterUpdate.CurrentPrize);
            Assert.AreEqual(newCurrentGame.CurrentBet, currentGameAfterUpdate.CurrentBet);
        }

        [TestMethod()]
        public void DeleteCurrentGameTest()
        {
            int currentGameIndex = new Random().Next(0, context.currentGames.Count);
            var currentGame = context.currentGames[currentGameIndex];
            Assert.IsTrue(context.currentGames.Contains(currentGame));
            repository.DeleteCurrentGame(currentGame);
            Assert.IsFalse(context.currentGames.Contains(currentGame));
        }

        // test for Event class _________________________________________________

        [TestMethod()]
        public void AddEventTest()
        {
            int beforeSize = context.events.Count;
            var beforeLastEvent = context.events.Last();
            var eventToAdd = new Event();
            {
                CurrentGame = new CurrentGame()
                {
                    StartGameTime = new DateTimeOffset(year: 2019, month: 1, day: 02, hour: 14, minute: 18, second: 00, offset: new TimeSpan(1, 0, 0)),
                    EndGameTime = new DateTimeOffset(DateTime.MaxValue),
                    Game = new Game()
                    {
                        ID = 888,
                        Title = "EightEightEight",
                        MaxPrize = 888888888.9,
                        MinBet = 88.0,
                        MaxPlayers = 88,
                        MinPlayers = 8
                    }
                };

                User = new User()
                {
                    ID = "18",
                    Age = 18,
                    FirstName = "Eight",
                    LastName = "Teen",
                    Telephone = "+48 888 888 888"

                };
            }
            
            repository.AddEvent(eventToAdd);
            int afterSize = context.events.Count;
            var afterLastEvent = context.events.Last();

            // check sizes
            Assert.AreNotEqual(beforeSize, afterSize);

            // check if last books aren't equal
            Assert.AreNotEqual(beforeLastEvent, afterLastEvent);

            // check if the book is in the list
            Assert.IsTrue(context.events.Contains(eventToAdd));
        }

        [TestMethod()]
        public void GetEventTest()
        {
            int eventIndex = new Random().Next(0, context.events.Count);
            var expectedEvent = context.events[eventIndex];
            Assert.AreEqual(expectedEvent, repository.GetEvent(eventIndex));

        }

        [TestMethod()]
        public void GetAllEventsTest()
        {
            var expectedEvents = context.events;
            Assert.AreEqual(expectedEvents, repository.GetAllEvents());
        }

        [TestMethod()]
        public void UpdateEventTest()
        {
            int eventIndex = context.events.Count - 1;
            var oldEvent = repository.GetEvent(eventIndex);
            var newEvent = new Event()
            {
                CurrentGame = new CurrentGame()
                {
                    StartGameTime = new DateTimeOffset(year: 2019, month: 1, day: 02, hour: 14, minute: 18, second: 00, offset: new TimeSpan(1, 0, 0)),
                    EndGameTime = new DateTimeOffset(DateTime.MaxValue),
                    Game = new Game()
                    {
                        ID = 999,
                        Title = "NineNineNine 999",
                        MaxPrize = 9999999.9,
                        MinBet = 999.0,
                        MaxPlayers = 99,
                        MinPlayers = 9
                    }
                },

                User = new User()
                {
                ID = "19",
                Age = 19,
                FirstName = "Nine",
                LastName = "Teen",
                Telephone = "+48 999 999 999"

                }

            };
            int beforeSize = context.events.Count;
            repository.UpdateEvents(oldEvent, newEvent);
            int afterSize = context.events.Count;

            var eventAfterUpdate = repository.GetEvent(eventIndex);

            // compare sizes
            Assert.AreEqual(beforeSize, afterSize);

            // compare references
            Assert.IsFalse(object.ReferenceEquals(eventAfterUpdate, newEvent));

            // compare properties
            Assert.AreEqual(newEvent.User, eventAfterUpdate.User);
            Assert.AreEqual(newEvent.CurrentGame, eventAfterUpdate.CurrentGame);
            Assert.AreEqual(newEvent.StartGameTime, eventAfterUpdate.StartGameTime);
            Assert.AreEqual(newEvent.EndGameTime, eventAfterUpdate.EndGameTime);
        }

        [TestMethod()]
        public void DeleteEventTest()
        {
            int eventIndex = new Random().Next(0, context.events.Count);
            var event1 = context.events[eventIndex];
            Assert.IsTrue(context.events.Contains(event1));
            repository.DeleteEvent(event1);
            Assert.IsFalse(context.events.Contains(event1));
        }
    }
}
