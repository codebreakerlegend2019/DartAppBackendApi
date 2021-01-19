using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Interfaces
{
    public interface ICud<T> where T : class
    {
        void Create(T model);
        void Delete(T model);
        void Update(object newUpdate, T modelToBeUpdated);
    }
}
