using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Dtos.ArtworkDtos
{
    public class ArtworkUpdateDto
    {
        public int ArtworkIdToUpdate { get; set; }
        public string NewTitle { get; set; }
        public string NewNotes { get; set; }
        public List<int> NewArtistIds { get; set; }
    }
}
