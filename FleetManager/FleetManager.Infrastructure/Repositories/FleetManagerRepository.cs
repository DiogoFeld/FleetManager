using FleetManager.Application.Interfaces;
using FleetManager.Application.Ultility;
using FleetManager.Domain.Entities;
using FleetManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.Infrastructure.Repositories
{
    public class FleetManagerRepository : IFleetManagerRepository
    {

        private readonly FleetDbContext _context;

        public FleetManagerRepository(FleetDbContext context)
        {
            _context = context;
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }


        public async Task<bool> Add(Vehicle vehicle)
        {
            if (VehicleValidator.IsVehicleValid(vehicle))
            {
                _context.Add(vehicle);
                return await _context.SaveChangesAsync() > 0;
            }
            else
                return false;

        }

        public async Task<bool> Delete(Vehicle vehicle)
        {
            if (vehicle.Id == null)
                return false;

            _context.Vehicles.Remove(vehicle);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetChassisId(int id)
        {
            if (id == null)
                return null;

            var vehicle = await _context.Vehicles.FirstAsync(x => x.ChassisId.Number == id);
            if (vehicle == null)
                return null;

            return vehicle;
        }

        public async Task<bool> Update(Vehicle vehicle)
        {
            try
            {
                if (vehicle.Id == null)
                {
                    return false;
                }

                if (VehicleValidator.IsVehicleValid(vehicle))
                {
                    var formerVehicle = _context.Update(vehicle);
                    var result = await _context.SaveChangesAsync() > 0;

                    if (vehicle == null)
                    {
                        return false;
                    }

                    return false;

                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public async Task<Vehicle> GetById(int id)
        {
            var resultVehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == id);
            return resultVehicle;
        }


    }
}
