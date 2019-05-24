using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Application;
using CasinoData;
using CasinoDataModelLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestCasino
{
    /// <summary>
    /// Opis podsumowujący elementu XmlDataFillerTests
    /// </summary>
    [TestClass]
    public class XmlDataFillerTests
    {
        private int maxTimeDifference;
        private string fileName;
        private DataContext initialContext;
        private DataContext deserialisedContext;
        private RandomDataFiller randomFiller;
        private XmlDataFiller xmlFiller;

        public XmlDataFillerTests()
        {
            // maximum time difference in milliseconds
            maxTimeDifference = 1000;

            // name of the xml file
            fileName = "testContext.xml";

            // creating contexts and fillers
            initialContext = new DataContext();
            deserialisedContext = new DataContext();
            randomFiller = new RandomDataFiller()
            {
                NumberOfGames = 500,
                NumberOfCurrentGames = 500,
                NumberOfUsers = 500,
                NumberOfEvents = 500
            };
            xmlFiller = new XmlDataFiller()
            {
                FileName = fileName
            };
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Pobiera lub ustawia kontekst testu, który udostępnia
        ///funkcjonalność i informację o bieżącym przebiegu testu.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Dodatkowe atrybuty testu
        //
        // Można użyć następujących dodatkowych atrybutów w trakcie pisania testów:
        //
        // Użyj ClassInitialize do uruchomienia kodu przed uruchomieniem pierwszego testu w klasie
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Użyj ClassCleanup do uruchomienia kodu po wykonaniu wszystkich testów w klasie
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Użyj TestInitialize do uruchomienia kodu przed uruchomieniem każdego testu 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Użyj TestCleanup do uruchomienia kodu po wykonaniu każdego testu
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod()]
        public void FillTest()
        {
            // fill context using RandomDataFiller
            randomFiller.Fill(ref initialContext);

            // save the context to xml file
            FileStream writer = new FileStream(fileName, FileMode.Create);
            List<Type> types = new List<Type>
            {
                typeof(Event),
                typeof(Game),
                typeof(User),
                typeof(CurrentGame)
            };
            var dataContractSerializer = new DataContractSerializer(typeof(DataContext), types, Int32.MaxValue, false, true, null);
            dataContractSerializer.WriteObject(writer, initialContext);
            writer.Flush();
            writer.Close();

            // get time value just before beginning of filling context
            DateTimeOffset begin = DateTimeOffset.Now;

            // fill another context using XmlDataFiller
            xmlFiller.Fill(ref deserialisedContext);

            // get time value right after finishing filling
            DateTimeOffset end = DateTimeOffset.Now;

            // calc time difference in milliseconds
            int difference = end.Subtract(begin).Milliseconds;

            // check if context has been filled quickly enough
            Assert.IsTrue(difference < maxTimeDifference);

            // check if all data has been read from xml file properly
            var actualGames = deserialisedContext.games;
            var actualUsers = deserialisedContext.users;
            var actualCurrentGames = deserialisedContext.currentGames;
            var actualEvents = deserialisedContext.events;

            var expectedGames = initialContext.games;
            var expectedUsers = initialContext.users;
            var expectedCurrentGames = initialContext.currentGames;
            var expectedEvents = initialContext.events;

            // check game
            foreach (var game in actualGames)
            {
                Assert.IsTrue(expectedGames.Contains(game));
            }

            // check current game
            foreach (var currentGame in actualCurrentGames)
            {
                Assert.IsTrue(expectedCurrentGames.Contains(currentGame));
            }

            // check users
            foreach (var users in actualUsers)
            {
                Assert.IsTrue(expectedUsers.Contains(users));
            }

            // check events
            foreach (var e in actualEvents)
            {
                Assert.IsTrue(expectedEvents.Contains(e));
            }



        }




    }
}
