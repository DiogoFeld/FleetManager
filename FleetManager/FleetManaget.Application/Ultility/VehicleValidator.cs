using FleetManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Application.Ultility
{
    public static class VehicleValidator
    {
        public static bool IsVehicleValid(Vehicle vehicle) => vehicle switch
        {
            { _Type: TypeVehicle.Car, NumberOfPassengers: <= 4 } => true,
            { _Type: TypeVehicle.Truck, NumberOfPassengers: <= 1 } => true,
            { _Type: TypeVehicle.Bus, NumberOfPassengers: <= 42 } => true,
            _ => false
        };
    }
}
