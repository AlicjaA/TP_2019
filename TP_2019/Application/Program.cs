using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoData;


//Alicja Anszpergier 
//Dobromir Kata 176555

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
