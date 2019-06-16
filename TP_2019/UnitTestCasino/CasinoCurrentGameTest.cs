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
            int id = dataRepository.GetAllGames().Count();
            Game game = new Game(id, "Snake", 9999.0, 10.0, 1,1);

            CurrentGame currentGame = new CurrentGame();
            dataRepository.AddCurrentGame(currentGame);


           // Assertion
            Assert.AreEqual(currentGame, dataRepository.GetCurrentGame(id));
        }

        [TestMethod]
        public void DeleteCurrentGameTest()
        {

            CurrentGame currentGame = dataRepository.GetCurrentGame(2);
            dataRepository.DeleteCurrentGame(currentGame);


            // Assertion
            Assert.IsNull(dataRepository.GetCurrentGame(2));
        }

        [TestMethod]
        public void GetCurrentGameTest()
        {
            // Assertion
            Assert.AreEqual(1, dataRepository.GetCurrentGame(1).ID);
        }

        [TestMethod]
        public void UpdateCurrentGameTest()
        {
            CurrentGame oldCurrentGame = dataRepository.GetCurrentGame(1);

            Game game = new Game(3, "Snake", 9999.0, 10.0, 1, 1);

            DateTime localTime = new DateTime(2019, 01, 01, 00, 00, 00);


            CurrentGame currentGame = new CurrentGame(3, game, 4, 1000, 100, startGameTime:localTime, endGameTime:localTime );
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
