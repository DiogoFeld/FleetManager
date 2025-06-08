using FleetManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Application.Interfaces
{
    public interface IFleetManagerRepository : IRepository<Vehicle>
    {
        Task<Vehicle> GetChassisId(int id);




    }
}
