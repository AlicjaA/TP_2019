using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;

namespace CasinoData
{

    public partial class CasinoDataRepository
    {
        public void AddEvent(Event events)
        {
            dataContext.Events.Add(events);
            dataContext.SaveChanges();
        }

        public Event GetEvent(int id)
        {
            return dataContext.Events.FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<Event> GetAllEvents()
        {
                return dataContext.Events;
        }

        public void UpdateEvents(Event oldEvent, Event newEvent)
        {
                oldEvent.User = newEvent.User;
                oldEvent.CurrentGame = newEvent.CurrentGame;
                oldEvent.StartGameTime = newEvent.StartGameTime;
                oldEvent.EndGameTime = newEvent.EndGameTime;
                dataContext.SaveChanges();
        }

        public bool DeleteEvents(Event events)
        {
                dataContext.Events.Remove(events);
                dataContext.SaveChanges();
                return true;
        }
    }
}

