﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Interfaces
{
    public interface ICrud<T> where T: class
    {
        Task<List<T>> GetAll(bool isReferenceIncluded = false);
        Task<T> Get(int id, bool isReferenceIncluded = false);
        void Create(T model);

        void Delete(T model);
        void Update(object newUpdate, T modelToBeUpdated);
    }
}
