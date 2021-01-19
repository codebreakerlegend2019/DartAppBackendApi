using AutoMapper;
using DartAppSingapore.DataContexts;
using DartAppSingapore.Interfaces;
using DartAppSingapore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Persistence.LocationRepositories
{
    public class LocationRepo : ICrud<Location>
    {
        #region Fields
        private readonly DartAppContext _context;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public LocationRepo(DartAppContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public void Create(Location model)
        {
            _context.Add(model);
        }

        public void Delete(Location model)
        {
            _context.Remove(model);
        }

        public async Task<Location> Get(int id, bool isReferenceIncluded = false)
        {
            if (isReferenceIncluded == true)
                return await _context.Locations
                    .Include(x => x.Zone)
                    .FirstOrDefaultAsync(x => x.Id == id);
            return await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Location>> GetAll(bool isReferenceIncluded = false)
        {
            if (isReferenceIncluded == true)
                return await _context.Locations
                    .Include(x => x.Zone)
                    .ToListAsync();
            return await _context.Locations
                .ToListAsync();
        }

        public void Update(object newUpdate, Location modelToBeUpdated)
        {
            _mapper.Map(newUpdate, modelToBeUpdated);
        }
        #endregion
    }
}
