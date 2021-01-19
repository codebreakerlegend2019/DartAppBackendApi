using DartAppSingapore.DataContexts;
using DartAppSingapore.Interfaces;
using DartAppSingapore.Models;
using DartAppSingapore.Persistence.UnitOfWorkRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Persistence.ArtworkRepositories
{
    public class ArtworkRepo : ICrud<Artwork>, IArtworkRepo
    {
        #region Field

        private readonly DartAppContext _context;
        private readonly ICrud<Artist> _iCrudArtist;
        #endregion
        public ArtworkRepo(DartAppContext context,
            ICrud<Artist> iCrudArtist,
            IUnitOfWork unitOfWork)
        {
            this._context = context;
            this._iCrudArtist = iCrudArtist;
        }

        #region Methods

        public async Task<bool> AddArtists(List<int> artistIds, int artWorkId)
        {
            foreach (var artistId in artistIds)
            {
                var isArtistExist = await _iCrudArtist.Get(artistId) != null;
                if (isArtistExist)
                    _context.Add(new ArtistArtwork() { ArtworkId = artWorkId, ArtistId = artistId });
            }
            return await _context.SaveChangesAsync()>0;
        }
        public void Create(Artwork model)
        {
            model.DateTimeCreated = DateTime.Now;
            _context.Add(model);
        }

        public void Delete(Artwork model)
        {
            _context.Remove(model);
        }

        public async Task<Artwork> Get(int id, bool isReferenceIncluded = false)
        {
            return await _context.ArtWorks
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Artwork>> GetAll(bool isReferenceIncluded = false)
        {
            return await _context.ArtWorks
                .ToListAsync();
        }

        public void Update(object newUpdate, Artwork modelToBeUpdated)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
