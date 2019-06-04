using System;
using System.Linq;
using CasinoData;
using CasinoDataModelLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCasino
{
    [TestClass]
    public class CasinoGameTests
    {
        CasinoDataRepository dataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            IDbContext dbContext = new CasinoDataContextTest();
            dataRepository = new CasinoDataRepository(dbContext);
        }

        [TestMethod]
        public void GameAddTest()
        {
            Game game10 = new Game(10, "XXXXX", 9999999.0, 999.0, 10, 1);
            dataRepository.AddGame(game10);

            // Assertion
            Assert.AreEqual(game10, dataRepository.GetGame(10));
        }

        [TestMethod]
        public void GameDeleteTest()
        {
            dataRepository.DeleteGame(dataRepository.GetGame(10));

            // Assertion
            Assert.IsNull(dataRepository.GetGame(10));
        }

        [TestMethod]
        public void GetGameTest()
        {
            Game game = new Game(00, "GameZero");

            // Assertion
            Assert.AreEqual(game, dataRepository.GetGame(00));
        }

        [TestMethod]
        public void UpdateGameTest()
        {
            Game newGame = new Game(01, "GameOne");
            dataRepository.UpdateGame(dataRepository.GetGame(01), newGame);

            // Assertion
            Assert.AreEqual(newGame, dataRepository.GetGame(01));
        }

        [TestMethod]
        public void GetAllGamesTest()
        {
            // Assertion
            Assert.AreEqual(2, dataRepository.GetAllGames().Count());
        }
    }

}
