using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoData
{
    public class DataContext
    {
        public List<User> users;

        public Dictionary<string, Game> games;

        public ObservableCollection<Event> events;

        public List<CurrentGame> currentGames;


    }
}
