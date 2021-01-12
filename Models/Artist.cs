using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public bool IsEnabled { get; set; }
        public virtual ICollection<ArtistArtwork> ArtistArtworks { get; set; }
        public Artist()
        {
            ArtistArtworks = new Collection<ArtistArtwork>();
        }
    }
}
