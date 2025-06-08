using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FleetManager.Domain.Entities
{
    [Owned]
    public class ChassisId
    {
        [Required]
        [MaxLength(30)]
        public string Series { get; set; }
        [Required]
        [MaxLength(30)]
        public int Number { get; set; }
    }
}