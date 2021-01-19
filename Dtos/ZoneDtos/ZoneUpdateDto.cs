using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Dtos.ZoneDtos
{
    public class ZoneUpdateDto
    {
        public int ZoneIdToUpdate { get; set; }
        public string NewName { get; set; }
    }
}
