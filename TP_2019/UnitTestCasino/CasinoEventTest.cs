using System;
using System.Linq;
using CasinoData;
using CasinoDataModelLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            DateTimeOffset startDateTimeOffset = new DateTimeOffset(localTime, TimeZoneInfo.Local.GetUtcOffset(localTime));
            DateTimeOffset endDateTimeOffset = new DateTimeOffset();
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
            Assert.AreEqual(1, dataRepository.GetEvent(1));
        }

        [TestMethod]
        public void UpdateEventTest()
        {
            Event oldEvent = dataRepository.GetEvent(1);

            User user = new User(0, "Zero", "Zero", "+48000000000", 20);
            Game game = new Game(0, "GameZero", 100000.0, 100.0, 10, 2);
            DateTime localTime = new DateTime(2019, 01, 01, 12, 00, 00);
            DateTimeOffset dateTimeOffset = new DateTimeOffset(localTime, TimeZoneInfo.Local.GetUtcOffset(localTime));
            CurrentGame currentGame = new CurrentGame();
            Event newEvent = new Event(user, currentGame, startGameTime: localTime, endGameTime:localTime);

            dataRepository.UpdateEvents(oldEvent, newEvent);

            // Assertion
            Assert.AreEqual(100, dataRepository.GetEvent(1));
        }

        [TestMethod]
        public void GetAllEventsTest()
        {
            // Assertions
            Assert.AreEqual(2, dataRepository.GetAllEvents().Count());
        }
    }

}
