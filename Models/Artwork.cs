using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public virtual ICollection<ArtworkEvent> ArtworkEvents { get; set; }
        public virtual ICollection<ArtistArtwork> ArtistArtworks { get; set; }
        public Artwork()
        {
            IsEnabled = true;
            DateTimeCreated = DateTime.Now;
            ArtworkEvents = new Collection<ArtworkEvent>();
            ArtistArtworks = new Collection<ArtistArtwork>();
        }
    }
}
