using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public class DataRepository
    {
        private DataFiller filler;
        private DataContext data;

        public DataRepository(DataFiller dataFiller)
        {
            this.filler = dataFiller;
        }

        public DataContext Data
        {
            set => data = value;
        }

        public void Fill()
        {
            filler.Fill(ref data);
        }






    }
}
