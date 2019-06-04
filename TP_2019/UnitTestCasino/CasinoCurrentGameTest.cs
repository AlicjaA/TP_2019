using System;
using System.Linq;
using CasinoData;
using CasinoDataModelLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCasino
{
    [TestClass]
    public class CasinoCurrentGameTest
    {
        CasinoDataRepository dataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            IDbContext dbContext = new CasinoDataContextTest();
            dataRepository = new CasinoDataRepository(dbContext);
        }

        [TestMethod]
        public void AddCurrentGameTest()
        {
            Game game = new Game(5, "Snake", 9999.0, 10.0, 1,1);

            CurrentGame currentGame = new CurrentGame();
            dataRepository.AddCurrentGame(currentGame);


           // Assertion
            Assert.AreEqual(currentGame, dataRepository.GetCurrentGame(5));
        }

        [TestMethod]
        public void DeleteCurrentGameTest()
        {

            CurrentGame currentGame0 = dataRepository.GetCurrentGame(5);
            dataRepository.DeleteCurrentGame(currentGame0);


            // Assertion
            Assert.IsNull(dataRepository.GetCurrentGame(5));
        }

        [TestMethod]
        public void GetCurrentGameTest()
        {
            // Assertion
            Assert.AreEqual(1, dataRepository.GetCurrentGame(1));
        }

        [TestMethod]
        public void UpdateCurrentGameTest()
        {
            CurrentGame oldCurrentGame = dataRepository.GetCurrentGame(1);

            Game game = new Game(5,"Snake");
            
            CurrentGame currentGame = new CurrentGame();
            dataRepository.UpdateCurrentGame(oldCurrentGame, currentGame);

            // Assertion
            Assert.AreEqual(currentGame, dataRepository.GetCurrentGame(1));
        }

        [TestMethod]
        public void GetAllCurrentGameTest()
        {
            // Assertion
            Assert.AreEqual(2, dataRepository.GetAllCurrentGame().Count());
        }

    }

}
