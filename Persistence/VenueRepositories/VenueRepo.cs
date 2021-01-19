using AutoMapper;
using DartAppSingapore.DataContexts;
using DartAppSingapore.Interfaces;
using DartAppSingapore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Persistence.VenueRepositories
{
    public class VenueRepo : ICrud<Venue>
    {
        #region Fields
        private readonly DartAppContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public VenueRepo(DartAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public void Create(Venue model)
        {
            _context.Add(model);
        }

        public void Delete(Venue model)
        {
            _context.Remove(model);
        }

        public async Task<Venue> Get(int id, bool isReferenceIncluded = false)
        {
            if (isReferenceIncluded)
                return await _context.Venues
                    .Include(x => x.Location)
                        .ThenInclude(x => x.Zone)
                    .FirstOrDefaultAsync(x => x.Id == id);
            else
                return await _context.Venues
                  .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Venue>> GetAll(bool isReferenceIncluded = false)
        {
            if (isReferenceIncluded)
                return await _context.Venues
                    .Include(x => x.Location)
                        .ThenInclude(x => x.Zone)
                    .ToListAsync();
            else
                return await _context.Venues
                  .ToListAsync();
        }

        public void Update(object newUpdate, Venue modelToBeUpdated)
        {
            _mapper.Map(newUpdate, modelToBeUpdated);
        } 
        #endregion
    }
}
