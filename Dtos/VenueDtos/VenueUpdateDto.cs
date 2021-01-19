using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Dtos.VenueDtos
{
    public class VenueUpdateDto
    {
        public int VenueIdToUpdate { get; set; }
        public string NewName { get; set; }
        public int NewLocationId { get; set; }
    }
}
