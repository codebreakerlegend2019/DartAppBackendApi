using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Dtos.LocationDtos
{
    public class LocationUpdateDto
    {
        public int LocationIdToUpdate { get; set; }
        public string NewName { get; set; }
        public double NewLatitude { get; set; }
        public double NewLongitude { get; set; }
        public string NewType { get; set; }
        public int NewZoneId { get; set; }
    }
}
