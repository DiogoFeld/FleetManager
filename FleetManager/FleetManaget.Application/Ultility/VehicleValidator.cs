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
        static readonly int CarMaximun = 4;
        static readonly int BusMaximun = 42;
        static readonly int truckMaximun = 1;

        public static bool IsVehicleValid(Vehicle vehicle) => vehicle switch
        {
            { _Type: TypeVehicle.Car, NumberOfPassengers: var n } when n <= CarMaximun => true,
            { _Type: TypeVehicle.Truck, NumberOfPassengers: var n } when n <= truckMaximun => true,
            { _Type: TypeVehicle.Bus, NumberOfPassengers: var n } when n <= BusMaximun => true,
            _ => false
        };
    }
}
