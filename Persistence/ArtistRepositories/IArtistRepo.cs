using DartAppSingapore.Models;
using System.Collections.Generic;

namespace DartAppSingapore.Persistence.ArtistRepositories
{
    public interface IArtistRepo
    {
        void DeleteArtistArtoworkPairs(ICollection<ArtistArtwork> artistArtworks);
    }
}