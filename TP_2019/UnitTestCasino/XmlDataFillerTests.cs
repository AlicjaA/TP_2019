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
        public XmlDataFillerTests()
        {
            //
            // TODO: Dodaj tutaj logikę konstruktora
            //
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

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Dodaj logikę testu tutaj
            //
        }

       


    }
}
