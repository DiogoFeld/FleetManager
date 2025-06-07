using FleetManager.Domain.Entities;
using FleetManager.Application.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Infrastructure.Repositories
{
    internal class FleetManagerRepository : IFleetManagerRepository, IRepository<Vehicle>
    {
        public bool Add(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetChassisId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Vehicle entity)
        {
            throw new NotImplementedException();
        }
    }
}
