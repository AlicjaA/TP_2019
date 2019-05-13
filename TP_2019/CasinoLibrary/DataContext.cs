using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDataModelLibrary
{
    class DataContext
    {
        private List<User> users;
        private Dictionary<String, Game> games;
        private ObservableCollection<Events> events;
        private ObservableCollection<CurrentGame> currentGames;

        public DataContext()
        {
            users = new List<User>();
            games= new Dictionary<string, Game>();
            events= new ObservableCollection<Event>();
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
                    foreach (CurrentGame cd in e.NewItems)
                    {
                        Console.WriteLine(cd);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    Console.WriteLine("Game is over");
                    foreach (CurrentGame cd in e.OldItems)
                    {
                        Console.WriteLine(cd);
                    }
                }
            };
        }
    }
}
