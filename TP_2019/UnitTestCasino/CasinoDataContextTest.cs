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

            User user0 = new User(0, "AAAA", "AAAAAA",  "+48999999999", 00);
            User user1 = new User(1, "BBBB", "BBBBBB",  "+48888888888", 00);
            Users.Add(user0);
            Users.Add(user1);

            Game game0 = new Game(0,"TestGameZero", 9999999999.0,100.0,10,2);
            Game game1 = new Game(1, "TestGameOne", 10000.0,100.0,10,1);
            Games.Add(game0);
            Games.Add(game1);

            CurrentGame currentGame0 = new CurrentGame(0, game0, 4, 30000.0, 3000.0);
            CurrentGame currentGame1 = new CurrentGame(1, game1, 5, 50000.0, 1000.0);
            CurrentGames.Add(currentGame0);
            CurrentGames.Add(currentGame1);

            Event event0 = new Event(1,user0, currentGame0, DateTime.Now, DateTime.MaxValue);
            Event event1 = new Event(0,user1, currentGame1, DateTime.Now, DateTime.MaxValue);
            Events.Add(event0);
            Events.Add(event1);

            SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<CurrentGame> CurrentGames {get; set; }
        public DbSet<Event> Events { get; set; }
        
        
        public void SaveChanges() => base.SaveChanges();
    }
}
