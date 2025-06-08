using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Domain.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        public ChassisId ChassisId { get; set; }
        public TypeVehicle Type { get; set; }

        [Required]
        public int NumberOfPassengers { get; set; }

        [Required]
        [MaxLength(30)]
        public string Color{ get; set; }

    }
}
