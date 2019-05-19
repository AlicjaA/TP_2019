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
    [Serializable]
    public class DataContext
    {
        
        public List<User> users;

        public Dictionary<int, Game> games;

        public ObservableCollection<Event> events;

        public ObservableCollection<CurrentGame> currentGames;

        public DataContext()
        {
            users = new List<User>();
            games = new Dictionary<int, Game>();
            events = new ObservableCollection<Event>();
            currentGames = new ObservableCollection<CurrentGame>();


            events.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    Console.WriteLine("New player");
                    foreach (Event ev in e.NewItems)
                    {
                        Console.WriteLine(ev);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    Console.WriteLine("Player leaves Game");
                    foreach (Event ev in e.OldItems)
                    {
                        Console.WriteLine(ev);
                    }
                }
            };

            events.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    Console.WriteLine("New Game");
                    foreach (Event cd in e.NewItems)
                    {
                        Console.WriteLine(cd);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    Console.WriteLine("Game is over");
                    foreach (Event cd in e.OldItems)
                    {
                        Console.WriteLine(cd);
                    }
                }
            };


        }

    }
}
