using System;
using System.Linq;
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

        // test for User class
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

        }


        //_______________________________________________________












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



    }
}
