using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models.Locations
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int BuildingNumber { get; set; }
        [Required]
        public string PrimaryContactUsername { get; set; }
    }
}
