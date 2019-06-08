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
        private static CasinoDataRepository dataRepository;

        public static CasinoDataRepository CasinoDataRepository
        {
            get => dataRepository;
        }

        private static CasinoDataService dataService;

        public static CasinoDataService CasinoDataService
        {
            get => dataService;
        }

        public static void RegDataRepository(CasinoDataRepository dataRepository)
        {
            dataService = new CasinoDataService(dataRepository);
        }

    }
}
