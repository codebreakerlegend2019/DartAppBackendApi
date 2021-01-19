using DartAppSingapore.Dtos.LocationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Dtos.VenueDtos
{
    public class VenueWithLocationReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationWithZoneReadDto Location { get; set; }
    }
}
