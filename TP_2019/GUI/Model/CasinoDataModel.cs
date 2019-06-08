using CasinoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Model
{
    public static class CasinoDataModel
    {
        public static CasinoDataRepository CasinoDataRepository { get; private set; }

        public static CasinoDataService CasinoDataService { get; private set; }

        public static void RegDataRepository(CasinoDataRepository dataRepository)
        {
            CasinoDataRepository = dataRepository;
            CasinoDataService = new CasinoDataService(dataRepository);
        }

    }
}
