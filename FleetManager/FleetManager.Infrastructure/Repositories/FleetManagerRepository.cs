using FleetManager.Domain.Entities;
using FleetManager.Application.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using FleetManagerWebApp.Data;
using FleetManager.Application.Ultility;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FleetManager.Infrastructure.Repositories
{
    public class FleetManagerRepository : IFleetManagerRepository
    {

        private readonly FleetManagerWebAppContext _context;

        public FleetManagerRepository(FleetManagerWebAppContext context)
        {
            _context = context;
        }               

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }


        public async Task<bool> Add(Vehicle vehicle)
        {
            if (VehicleValidator.IsVehicleValid(vehicle))
            {
                _context.Add(vehicle);
                return await _context.SaveChangesAsync() > 0;
            }
            return true;
        }

        public async Task<bool> Delete(Vehicle vehicle)
        {
            if (vehicle.Id == null)
                return false;                 

            _context.Vehicle.Remove(vehicle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await _context.Vehicle.ToListAsync();
        }

        public async Task<Vehicle> GetChassisId(int id)
        {
            if (id == null)
                return null;

            var vehicle = await _context.Vehicle.FirstAsync(x => x.ChassisId.Number == id);
            if (vehicle == null)
                return null;

            return vehicle;
        }

        public async Task<bool> Update(Vehicle vehicle)
        {
            if (vehicle.Id == null)
            {
                return false;
            }

            var formerVehicle = await _context.Vehicle.FindAsync(vehicle.Id);
            if (vehicle == null)
            {
                return false;
            }

            formerVehicle.ChassisId.Series = vehicle.ChassisId.Series;
            formerVehicle.ChassisId.Number = vehicle.ChassisId.Number;
            formerVehicle.NumberOfPassengers = vehicle.NumberOfPassengers;
            formerVehicle.Color = vehicle.Color;
            formerVehicle.Type = vehicle.Type;

            return await _context.SaveChangesAsync() > 0;
        }

    }
}
