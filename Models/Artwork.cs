using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public bool IsEnabled { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
