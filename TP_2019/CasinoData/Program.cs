using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CasinoData;
using CasinoDataModelLibrary;


//Alicja Anszpergier 195755
//Dobromir Kata 176555

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {

            DataContext dataContext = new DataContext();

            //DataFiller dataFiller = new XmlDataFiller()
            //{
            //    FileName = "../../../XMLDataContext.xml"
            //};


            //DataFiller dataFiller = new ConstDataFiller();

            ///*
            DataFiller dataFiller = new RandomDataFiller()
            {
                NumberOfGames = 10,
                NumberOfCurrentGames = 10,
                NumberOfUsers = 10,
                NumberOfEvents = 10
            };
            //*/
            DataRepository dataRepository = new DataRepository(dataFiller)
            {
                Data = dataContext
            };
            dataRepository.Fill();

            DataService service = new DataService(dataRepository);

            Console.WriteLine(service.PrintAllBinded());

            FileStream writer = new FileStream("XMLDataContext.xml", FileMode.Create);

            //dodanie typów, które ma rozpoznać DataContractSerializer
            List<Type> types = new List<Type> { typeof(Event), typeof(Game), typeof(User), typeof(CurrentGame) };
            var dataContractSerializer = new DataContractSerializer(typeof(DataContext), types, 0x7FFF, false, true, null);
            dataContractSerializer.WriteObject(writer, dataContext);

            writer.Flush();
            writer.Close();


            //Console.ReadKey();
        }
    }
}
