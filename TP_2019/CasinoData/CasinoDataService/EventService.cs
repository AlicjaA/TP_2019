using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoDataModelLibrary;

namespace CasinoData
{
    public partial class CasinoDataService
    {
        public string PrintEvents(List<Event> events)
        {
            string eventString = "";

            foreach (Event event int events)
            {
                eventString += events;

                if (events.LastIndexOf(events) != events.Count)
                {
                    eventString += ", ";
                }
            }
            return eventString;
        }

        public void AddEvents(Event events)
        {
            if (!casinoDataRepository.GetAllEvents().Contains(events))
            {
                casinoDataRepository.AddEvent(events);
            }
            else
            {
                throw new Exception("Event alredy exists!");
            }
        }
        public bool DeleteEvent(Event events)
        {
            if (casinoDataRepository.GetAllEvents().Contains(events))
            {
                casinoDataRepository.DeleteEvent(events);
                return true;
            }
            else
            {
                throw new Exception("Event does not exists!");
            }
        }

        public void UpdateEvent(Event oldEvent, Event newEvent)
        {
            if (casinoDataRepository.GetAllEvents().Contains(oldEvent))
            {
                casinoDataRepository.UpdateEvents(oldEvent, newEvent);
            }
            else
            {
                throw new Exception("Error! Can't update or event does not exists!");
            }
        }
    }
}
