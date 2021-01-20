using DartAppSingapore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DartAppSingapore.Persistence.ArtworkRepositories
{
    public interface IArtworkRepo
    {
        Task AddArtists(List<int> artistIds, int artWorkId);
        void DeleteArtistArtworkPairs(ICollection<ArtistArtwork> artistArtworks);
    }
}