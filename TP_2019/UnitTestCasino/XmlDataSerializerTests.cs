using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Application;
using CasinoData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCasino
{
    /// <summary>
    /// Opis podsumowujący elementu XmlDataSerializerTests
    /// </summary>
    [TestClass]
    public class XmlDataSerializerTests
    {
        private RandomDataFiller dataFiller;
        private DataContext context;
        private string fileName;
        private XmlDataSerializer xmlSerializer;

        [TestInitialize]
        public void TestInitialize()
        {
            dataFiller = new RandomDataFiller()
            {
                NumberOfGames = 1000,
                NumberOfCurrentGames = 1000,
                NumberOfUsers = 1000,
                NumberOfEvents = 1000
            };
            context = new DataContext();
            dataFiller.Fill(ref context);
            fileName = "xmlData.xml";
            xmlSerializer = new XmlDataSerializer()
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
        public void SerializeTest()
        {
            // first delete the file if it already exists
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // serialize
            xmlSerializer.Serialize(context);
            Assert.IsTrue(File.Exists(fileName));
        }
    }
}
