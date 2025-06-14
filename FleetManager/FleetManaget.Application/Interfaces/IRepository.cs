﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
         Task<bool> Add(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
         Task<bool> Update(T entity);
         Task<bool> Delete(T entity);
    }
}
