using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasinoData;
using Application;

namespace UnitTestCasino
{
    [TestClass()]
    public class JSONSerializerTests
    {
        private RandomDataFiller dataFiller;
        private DataContext context;
        private string fileName;
        private JSONSerializer jsonSerializer;

        [TestInitialize]
        public void TestInitialize()
        {
            dataFiller = new RandomDataFiller()
            {
                NumberOfGames = 500,
                NumberOfCurrentGames = 500,
                NumberOfUsers = 500,
                NumberOfEvents = 500
            };
            context = new DataContext();
            dataFiller.Fill(ref context);
            fileName = "jsonDataCasino.json";
            jsonSerializer = new JSONSerializer()
            {
                FileName = fileName
            };
        }

        [TestMethod()]
        public void DeserializeTest()
        {
            // first delete the file if it already exists
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // serialize
            jsonSerializer.Serialize(context);

            var newContext = new DataContext();

            jsonSerializer.Deserialize(ref newContext);

            // check collection sizes
            Assert.AreEqual(context.users.Count, newContext.users.Count);
            Assert.AreEqual(context.currentGames.Count, newContext.currentGames.Count);
            Assert.AreEqual(context.games.Count, newContext.games.Count);
            Assert.AreEqual(context.events.Count, newContext.events.Count);

            // check if collections contain objects with the same properties
            foreach (var game in context.games.Values)
            {
                Assert.IsTrue(newContext.games.ContainsValue(game));
            }

            foreach (var currentGame in context.currentGames)
            {
                Assert.IsTrue(newContext.currentGames.Contains(currentGame));
            }

            foreach (var user in context.users)
            {
                Assert.IsTrue(newContext.users.Contains(user));
            }

            foreach (var e in context.events)
            {
                Assert.IsTrue(newContext.events.Contains(e));
            }

            // check user references in user states
            foreach (var game in newContext.games.Values)
            {
                var currentGamesAll = newContext.currentGames.Where(e => e.Game.Equals(game)).ToList();

                if (currentGamesAll.Count > 0)
                {
                    foreach (var currentGame in currentGamesAll)
                    {
                        Assert.IsTrue(object.ReferenceEquals(game, currentGame.Game));
                    }
                }
            }

            // check user state references in events
            foreach (var currentGame in newContext.currentGames)
            {
                var events = newContext.events.Where(e => e.CurrentGame.Equals(currentGame)).ToList();

                if (events.Count > 0)
                {
                    foreach (var ev in events)
                    {
                        Assert.IsTrue(object.ReferenceEquals(currentGame, ev.CurrentGame));
                    }
                }
            }

            // check user reader references in events
            foreach (var user in newContext.users)
            {
                var events = newContext.events.Where(e => e.User.Equals(user)).ToList();

                if (events.Count > 0)
                {
                    foreach (var ev in events)
                    {
                        Assert.IsTrue(object.ReferenceEquals(user, ev.User));
                    }
                }
            }
        }

        [TestMethod()]
        public void SerializeTest()
        {
            // first delete the file if it already exists
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // serialize
            jsonSerializer.Serialize(context);
            Assert.IsTrue(File.Exists(fileName));
        }
    }
}
