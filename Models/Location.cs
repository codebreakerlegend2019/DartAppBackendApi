using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Type { get; set; }
        public int ZoneId { get; set; }
        public virtual Zone Zone { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public bool IsEnabled { get; set; }
    }
}
