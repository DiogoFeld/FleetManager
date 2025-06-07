using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);
        IEnumerable<T> GetAll();
        bool Update(T entity);
        void Delete(T entity);
    }
}
