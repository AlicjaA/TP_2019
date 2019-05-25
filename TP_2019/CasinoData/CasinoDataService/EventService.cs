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

            foreach (Event event in events)
            {
                eventString += events;

                if (events.LastIndexOf(event) != events.Count)
                {
                    eventString += ", ";
                }
            }

            return eventString;
        }

        public void AddEvents(Event event)
        {
            if (!casinoDataRepository.GetAllEvents().Contains(event))
            {
                casinoDataRepository.AddEvent(events:);
            }
            else
            {
                throw new Exception("Participation alredy exists!");
            }
        }
    }
}
