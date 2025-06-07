using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Domain.Entities
{
    public class Vehicle
    {
        public ChassisId ChassisId { get; set; }
        public TypeVehicle Type { get; set; }
        public int NumberOfPassengers { get; set; }
        public string Color{ get; set; }

    }
}
