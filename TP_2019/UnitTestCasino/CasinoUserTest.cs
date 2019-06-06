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
            User user3 = new User(3, "Dobromir", "Kata", "+48999999999",00);
            User user4 = new User(4, "Alicja", "Anszpergier", "+48888888888",00);

            dataRepository.AddUser(user3);
            dataRepository.AddUser(user4);

            Assert.AreEqual(user3, dataRepository.GetUser(3));
            Assert.AreEqual(user4, dataRepository.GetUser(4));

            


        }



        [TestMethod]
        public void DeleteUserTest()
        {
            dataRepository.DeleteUser(dataRepository.GetUser(2));

            Assert.IsNull(dataRepository.GetUser(2));
        }

        [TestMethod]
        public void GetUserTest()
        {
            User user3= new User(3, "Dobromir", "Kata", "+48999999999",00);
            User user4= new User(4, "Alicja", "Anszpergier", "+48888888888", 00);
            dataRepository.AddUser(user3);
            dataRepository.AddUser(user4);

            // Assertion
            Assert.AreEqual(user3, dataRepository.GetUser(3));
            Assert.AreEqual(user4, dataRepository.GetUser(4));
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            User newUser = new User(2, "Dobromir", "Kata", "+48999999999",36);
            //User newUser4= new User(4, "Alicja", "Anszpergier", "+48888888888", 00);
            dataRepository.UpdateUser(dataRepository.GetUser(2), newUser);
            //dataRepository.UpdateUser(dataRepository.GetUser(4), newUser4);

            // Assertion
            Assert.AreEqual(newUser, dataRepository.GetUser(2));
            //Assert.AreEqual(newUser4, dataRepository.GetUser(4));
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            // Assertion
            Assert.AreEqual(2, dataRepository.GetAllUsers().Count());
        }


    }
}
