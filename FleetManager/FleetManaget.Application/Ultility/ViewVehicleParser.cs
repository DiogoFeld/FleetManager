using FleetManager.Domain.Entities;
using FleetManager.Domain.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Application.Ultility
{
    public static class ViewVehicleParser
    {

        public static Vehicle Parse(ViewVehicle viewVehicle)
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


    }
}
