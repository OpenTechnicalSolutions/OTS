using OpenTicketSystem.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.ViewModels
{
    public class BuildingDetailsViewModel
    {
        public Building Building { get; set; }
        public BuildingRoomsViewModel Rooms { get; set; }
    }
}
