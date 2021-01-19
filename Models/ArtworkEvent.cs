using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Models
{
    public class ArtworkEvent
    {
        public int ArtworkId { get; set; }
        public virtual Artwork Artwork { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
