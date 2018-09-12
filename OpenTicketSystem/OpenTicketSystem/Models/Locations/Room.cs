using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models.Locations
{
    public class Room : Location
    {
        public int BuildingId { get; set; }
        public string PrimaryContactUsername { get; set; }
    }
}
