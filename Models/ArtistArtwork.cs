using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Models
{
    public class ArtistArtwork
    {
        public int ArtworkId { get; set; }
        public virtual Artwork Artwork { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
