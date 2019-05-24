using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Application;
using CasinoData;
using CasinoDataModelLibrary;
using Application;
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
            

            

        }




    }
}
