using AutoMapper;
using DartAppSingapore.DataContexts;
using DartAppSingapore.Interfaces;
using DartAppSingapore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Persistence.ZoneRepositories
{
    public class ZoneRepo : ICrud<Zone>
    {
        #region Fields
        private readonly DartAppContext _context;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public ZoneRepo(DartAppContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion
        #region Methods
        public void Create(Zone model)
        {
            _context.Add(model);
        }

        public void Delete(Zone model)
        {
            _context.Remove(model);
        }

        public async Task<Zone> Get(int id, bool isReferenceIncluded = false)
        {
            return await _context.Zones.FindAsync(id);
        }

        public async Task<List<Zone>> GetAll(bool isReferenceIncluded = false)
        {
            return await _context.Zones.ToListAsync();
        }

        public void Update(object newUpdate, Zone modelToBeUpdated)
        {
            _mapper.Map(newUpdate, modelToBeUpdated);
        }
        #endregion
    }
}
