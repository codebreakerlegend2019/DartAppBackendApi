using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int VenueId { get; set; }
        public virtual Venue Venue { get; set; }
        public string DateTimeCreated { get; set; }
        public bool IsEnabled { get; set; }
        public virtual ICollection<ArtworkEvent> ArtworkEvents { get; set; }
        public Event()
        {
            ArtworkEvents = new Collection<ArtworkEvent>();
        }
    }
}
