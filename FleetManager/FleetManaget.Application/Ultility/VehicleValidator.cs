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
            { _Type: TypeVehicle.Car, NumberOfPassengers: var n } when n <= 4 => true,
            { _Type: TypeVehicle.Truck, NumberOfPassengers: var n } when n <= 1 => true,
            { _Type: TypeVehicle.Bus, NumberOfPassengers: var n } when n <= 43 => true,
            _ => false
        };
    }
}
