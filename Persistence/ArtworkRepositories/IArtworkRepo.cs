using DartAppSingapore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DartAppSingapore.Persistence.ArtworkRepositories
{
    public interface IArtworkRepo
    {
        Task<bool> AddArtists(List<int> artistIds, int artWorkId);
        Task<bool> DeleteArtistArtworkPairs(ICollection<ArtistArtwork> artistArtworks);
    }
}