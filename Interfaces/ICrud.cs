using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Interfaces
{
    public interface ICrud<T> where T: class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        void Create(T model);

        void Delete(T model);
        void Update(object newUpdate, T modelToBeUpdated);
    }
}
