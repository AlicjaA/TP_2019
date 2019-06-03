using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CasinoData;
using CasinoDataModelLibrary;

namespace UnitTestCasino
{
    class CasinoDataContextTest : DbContext, IDbContext
    {
        public CasinoDataContextTest() : base()
        {
            Database.Delete();
            Database.Create();

            User user0 = new User(0, "AAAA", "AAAAAA",  "+48000000000", 20);
            User user1 = new User(1, "BBBB", "BBBBBB",  "+48111111111", 21);
            Users.Add(user0);
            Users.Add(user1);

            Game game0 = new Game(0,"TestGameZero", 2.0,1.0,2,2);
            Game game1 = new Game(1, "TestGameOne", 10000.0,100.0,10,1);
            Games.Add(game0);
            Games.Add(game1);


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<CurrentGame> CurrentGames {get; set; }
        public DbSet<Event> Events { get; set; }

        public void SaveChanges() => base.SaveChanges();
    }
}
