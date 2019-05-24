using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;
using System.Data.Entity;

namespace CasinoData
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<CurrentGame> CurrentGames {get; set; }
        DbSet<Event> Events { get; set; }
        void SaveChanges();
    }
}
