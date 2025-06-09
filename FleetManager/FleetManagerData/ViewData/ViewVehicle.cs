using FleetManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Domain.ViewData
{
    public class ViewVehicle
    {        
        public int Id { get; set; }
        public ChassisId ChassisId { get; set; }

        public TypeVehicle _Type { get; set; }

        public int NumberOfPassengers { get; set; }

        public string Color { get; set; }

        public string Series { get; set; }
        public int Number { get; set; }


    }
}
