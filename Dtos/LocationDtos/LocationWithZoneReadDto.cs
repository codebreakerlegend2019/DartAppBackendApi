using DartAppSingapore.Dtos.ZoneDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Dtos.LocationDtos
{
    public class LocationWithZoneReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Type { get; set; }
        public ZoneReadDto Zone { get; set; }
    }
}
