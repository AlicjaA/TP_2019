using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    class Program
    {
        static void Main(string[] args)
        {

            DataContext dataContext = new DataContext();


            DataFiller dataFiller = new ConstDataFiller();

            DataFiller dataFiller1 = new RandomDataFiller()
            {
                NumberOfGames = 10,
                NumberOfCurrentGames = 10,
                NumberOfUsers = 10,
                NumberOfEvents = 10
            };

            DataRepository dataRepository = new DataRepository()
            {
                Data = dataContext
            };
            dataRepository.Filler=dataFiller;
             dataRepository.Fill();
            dataRepository.Filler = dataFiller1;
            dataRepository.Fill();


            Console.ReadKey();
        }
    }
}
