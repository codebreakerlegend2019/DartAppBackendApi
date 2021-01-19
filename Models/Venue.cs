using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public bool IsEnabled { get; set; }
    }
}
