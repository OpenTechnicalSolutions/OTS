using OpenTicketSystem.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.ViewModels
{
    public class RoomDetailsViewModel
    {
        public int BuildingNumber { get; set; }
        public Room Room { get; set; }
    }
}
