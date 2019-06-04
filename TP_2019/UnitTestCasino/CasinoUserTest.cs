using System;
using System.Linq;
using CasinoData;
using CasinoDataModelLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCasino
{
    [TestClass]
    public class CasinoUserTest
    {
        CasinoDataRepository dataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            IDbContext dbContext = new CasinoDataContextTest();
            dataRepository = new CasinoDataRepository(dbContext);
        }


        [TestMethod]
        public void AddUserTest()
        {
            User user0 = new User(176555, "Dobromir", "Kata", "+48999999999",00);
            User user1 = new User(195755, "Alicja", "Anszpergier", "+48888888888",00);
            
            Assert.AreEqual(user0, dataRepository.GetUser(176555));
            Assert.AreEqual(user1, dataRepository.GetUser(195755));
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            dataRepository.DeleteUser(dataRepository.GetUser(00));
            dataRepository.DeleteUser(dataRepository.GetUser(01));

            Assert.IsNull(dataRepository.GetUser(00));
            Assert.IsNull(dataRepository.GetUser(01));
        }

        [TestMethod]
        public void GetUserTest()
        {
            User user0= new User(176555, "Dobromir", "Kata", "+48999999999",00);
            User user1= new User(195755, "Alicja", "Anszpergier", "+48888888888", 00);
            dataRepository.AddUser(user0);
            dataRepository.AddUser(user1);

            // Assertion
            Assert.AreEqual(user0, dataRepository.GetUser(176555));
            Assert.AreEqual(user1, dataRepository.GetUser(195755));
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            User newUser0 = new User(00, "Dobromir", "Kata", "+48999999999",00);
            User newUser1 = new User(01, "Alicja", "Anszpergier", "+48888888888", 00);
            dataRepository.UpdateUser(dataRepository.GetUser(00), newUser0);
            dataRepository.UpdateUser(dataRepository.GetUser(01), newUser1);

            // Assertion
            Assert.AreEqual(newUser0, dataRepository.GetUser(00));
            Assert.AreEqual(newUser1, dataRepository.GetUser(01));
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            // Assertion
            Assert.AreEqual(2, dataRepository.GetAllUsers().Count());
        }


    }
}
