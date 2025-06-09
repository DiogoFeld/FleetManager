using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FleetManager.Domain.Entities
{
    [Owned]
    public class ChassisId
    {
        [Required]
        [MaxLength(30)]
        [DisplayName("Chassis Series")]
        public string Series { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Chassis Number")]
        public int Number { get; set; }
    }
}