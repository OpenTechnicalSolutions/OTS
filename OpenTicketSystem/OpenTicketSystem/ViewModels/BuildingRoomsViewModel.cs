using OpenTicketSystem.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.ViewModels
{
    public class BuildingRoomsViewModel
    {
        public List<Room> Rooms { get; set; }
        public int BuildingNumber { get; set; }
    }
}
