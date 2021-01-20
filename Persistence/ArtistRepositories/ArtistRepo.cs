using DartAppSingapore.DataContexts;
using DartAppSingapore.Interfaces;
using DartAppSingapore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Persistence.ArtistRepositories
{
    public class ArtistRepo : ICrud<Artist>, IArtistRepo
    {
        #region Fields
        private readonly DartAppContext _context;
        #endregion
        public ArtistRepo(DartAppContext context)
        {
            this._context = context;
        }
        #region ICrud Methods
        public void Create(Artist model)
        {
            model.DateTimeCreated = DateTime.Now;
            _context.Add(model);
        }

        public void Delete(Artist model)
        {
            _context.Remove(model);
        }

        public async Task<Artist> Get(int id, bool isReferenceIncluded = false)
        {
            return await _context.Artists
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Artist>> GetAll(bool isReferenceIncluded = false)
        {
            return await _context.Artists
                .Include(x => x.ArtistArtworks)
                .ToListAsync();
        }

        public void Update(object newUpdate, Artist modelToBeUpdated)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region ArtistRepo Methods
        public void DeleteArtistArtoworkPairs(ICollection<ArtistArtwork> artistArtworks)
        {
            _context.RemoveRange(artistArtworks);
        }
        #endregion
    }
}
