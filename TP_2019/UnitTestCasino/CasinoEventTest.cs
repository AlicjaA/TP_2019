using CasinoData;
using CasinoDataModelLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestCasino
{
    [TestClass]
    public class CasinoEventTest
    {
        CasinoDataRepository dataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            IDbContext dbContext = new CasinoDataContextTest();
            dataRepository = new CasinoDataRepository(dbContext);
        }

        [TestMethod]
        public void AddEventTest()
        {
            User user = new User(0, "Zero", "Zero", "+48000000000", 20);
            Game game = new Game(0, "GameZero", 100000.0, 100.0, 10, 2);
            DateTime localTime = new DateTime(2019, 01, 01, 11,00,00);
            DateTime startDateTimeOffset = localTime;
            DateTime endDateTimeOffset = new DateTime();
            CurrentGame currentGame = new CurrentGame();
            Event events = new Event(user, currentGame, startGameTime: localTime, endGameTime:localTime);

            dataRepository.AddEvent(events);

            // Assertion
            Assert.AreEqual(events, dataRepository.GetEvent(3));
        }

        [TestMethod]
        public void DeleteEventTest()
        {
            dataRepository.DeleteEvents(dataRepository.GetEvent(1));

            // Assertion
            Assert.AreEqual(1, dataRepository.GetAllEvents().Count());
        }

        [TestMethod]
        public void GetEventTest()
        {
            // Assertion
            Assert.AreEqual(1, dataRepository.GetEvent(1).ID);
        }

        [TestMethod]
        public void UpdateEventTest()
        {
            Event oldEvent = dataRepository.GetEvent(1);

            User user = new User(3, "AAAA", "AAAAAA", "+48999999999", 00);
            Game game = new Game(3, "TestGameThree", 9999999999.0, 100.0, 10, 2);

            DateTime localTime = new DateTime(2019, 01, 01, 12, 00, 00);
            
            DateTime startGameTime = localTime;
            DateTime endGameTime = localTime;
            
            //DateTimeOffset startGameTime = new DateTimeOffset();
            //DateTimeOffset endGameTime = new DateTimeOffset();

            CurrentGame currentGame = new CurrentGame(3, game, 4, 30000.0, 3000.0);
            Event newEvent = new Event(200,user, currentGame, startGameTime, endGameTime);

            dataRepository.UpdateEvents(oldEvent, newEvent);

            // Assertion
            Assert.AreEqual(1, dataRepository.GetEvent(1).ID);
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            // Assertions
            Assert.AreEqual(2, dataRepository.GetAllEvents().Count());
        }
    }

}
