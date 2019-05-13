using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;

namespace CasinoData
{
    public class DataContext
    {
        [Serializable]
        public List<User> user;

        public Dictionary<string, Game> game;

        public ObservableCollection<Event> events;

        public List<CurrentGame> currentGame;

        public DataContext()
        {
            user = new List<User>();
            game = new Dictionary<string, Game>();
            events = new ObservableCollection<Event>();
            currentGame = new List<CurrentGame>();

            // initialize event handlers for ObservableCollection
            events.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    Console.WriteLine("Rozpoczęto grę");
                    foreach (Event ev in e.NewItems)
                    {
                        Console.WriteLine(ev);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    Console.WriteLine("Zakończono grę");
                    foreach (Event ev in e.OldItems)
                    {
                        Console.WriteLine(ev);
                    }

                }
            };


        }

    }
}
