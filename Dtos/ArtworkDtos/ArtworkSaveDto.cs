using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Dtos.ArtworkDtos
{
    public class ArtworkSaveDto
    { 
        public string Title { get; set; }
        public string Notes { get; set; }
        public List<int> ArtistIds { get; set; }
    }
}
