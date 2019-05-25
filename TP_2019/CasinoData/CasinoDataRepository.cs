using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CasinoData
{
    public partial class CasinoDataRepository
    {
        private IDbContext dataContext;

        public IDbContext DataContext
        {
            set => dataContext = value;
        }

        public CasinoDataRepository(IDbContext dbContext)
        {
            dataContext = dbContext;
        }
    }
}
