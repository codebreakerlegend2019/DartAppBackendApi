using DartAppSingapore.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Persistence.UnitOfWorkRepositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly DartAppContext _context;
        #endregion

        public UnitOfWork(DartAppContext context)
        {
            this._context = context;
        }

        public async Task<bool> SuccessSaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
