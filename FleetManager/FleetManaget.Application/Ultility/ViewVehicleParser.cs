using FleetManager.Domain.Entities;
using FleetManager.Domain.ViewData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FleetManager.Application.Ultility
{
    public static class ViewVehicleParser
    {

        public static Vehicle ParseToVehicle(ViewVehicle viewVehicle)
        {
            Vehicle vehicle = new Vehicle()
            {
                Id = viewVehicle.Id,
                _Type = viewVehicle._Type,
                NumberOfPassengers = viewVehicle.NumberOfPassengers,
                Color = viewVehicle.Color,
                ChassisId = new ChassisId()
                {
                    Number = viewVehicle.Number,
                    Series = viewVehicle.Series
                }
            };

            return vehicle;
        }

        public static ViewVehicle ParseFromVehicle(Vehicle vehicle)
        {

            ViewVehicle viewVehicle = new ViewVehicle()
            {
                Id = vehicle.Id,
                _Type = vehicle._Type,
                NumberOfPassengers = vehicle.NumberOfPassengers,
                Color = vehicle.Color,
                Series = vehicle.ChassisId != null ? vehicle.ChassisId.Series : "",
                Number = vehicle.ChassisId != null ? vehicle.ChassisId.Number : 0,
            };

            return viewVehicle;

        }



    }
}
