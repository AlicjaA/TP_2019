using System;
using CasinoData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCasino
{
    [TestClass]
    public class CasinoDataRepositoryTest
    {
        CasinoDataRepository dataRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            IDbContext dbContext = new TestCasinoDataContext();
            dataRepository = new CasinoDataRepository(dbContext);
        }


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
