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
                ID = "000",
                Age = 36,
                FirstName = "ABCDEFG",
                LastName = "HIJKLMNOP",
                Telephone = "000000000"
            };
            repository.AddUser(userToAdd);
            int afterSize = context.users.Count;
            var afterLastUser = context.users.Last();
        }





    }
}
