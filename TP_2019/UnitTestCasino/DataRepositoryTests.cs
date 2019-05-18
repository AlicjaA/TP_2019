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














        // test for Event class _________________________________________________


    }
}
