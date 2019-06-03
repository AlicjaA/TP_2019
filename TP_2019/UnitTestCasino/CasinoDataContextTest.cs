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

            User user00 = new User(0, "AAAA", "AAAAAA",  "+48000000000", 20);
            User user01 = new User(1, "BBBB", "BBBBBB",  "+48111111111", 21);
            Users.Add(user00);
            Users.Add(user01);

            Game game00 = new Game(0,"TestGameZero", 9999999999.0,100.0,10,2);
            Game game01 = new Game(1, "TestGameOne", 10000.0,100.0,10,1);
            Games.Add(game00);
            Games.Add(game01);

            CurrentGame currentGame00 = new CurrentGame(0, game00, 4, 30000.0, 3000.0);
            CurrentGame currentGame01 = new CurrentGame(1, game01, 5, 50000.0, 1000.0);
            CurrentGames.Add(currentGame00);
            CurrentGames.Add(currentGame01);

            Event event00 = new Event(user00, currentGame00, DateTimeOffset.Now, DateTimeOffset.MaxValue);
            Event event01 = new Event(user01, currentGame01, DateTimeOffset.Now, DateTimeOffset.MaxValue);
            Events.Add(event00);
            Events.Add(event01);

            SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<CurrentGame> CurrentGames {get; set; }
        public DbSet<Event> Events { get; set; }

        public void SaveChanges() => base.SaveChanges();
    }
}
