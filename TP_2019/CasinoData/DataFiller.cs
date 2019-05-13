using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public abstract class DataFiller
    {
        public abstract void Fill(ref DataContext context);
    }
}
