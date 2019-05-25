using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public partial class CasinoDataService
    {
        private CasinoDataRepository casinoDataRepository;

        public CasinoDataService(CasinoDataRepository casinoDataRepository)
        {
            this.casinoDataRepository = casinoDataRepository;
        }
    }
}
