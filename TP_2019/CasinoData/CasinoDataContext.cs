using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;

namespace CasinoData
{
    public class CasinoDataContext : DbContext, IDbContext
    {
        public CasinoDataContext(): base() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<CurrentGame> CurrentGames { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CasinoDataContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public void SaveChanges() => base.SaveChanges();
       
    }
}
