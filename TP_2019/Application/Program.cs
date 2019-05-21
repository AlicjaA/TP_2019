using System;
using CasinoData;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {

            DataContext dataContext = new DataContext();


            //DataFiller dataFiller = new ConstDataFiller();

            DataFiller dataFiller = new RandomDataFiller()
            {
                NumberOfGames = 10,
                NumberOfCurrentGames = 10,
                NumberOfUsers = 10,
                NumberOfEvents = 10
            };

            DataRepository dataRepository = new DataRepository(dataFiller)
            {
                Data = dataContext
            };
            dataRepository.Fill();
            

            Console.ReadKey();
        }
    }
}
