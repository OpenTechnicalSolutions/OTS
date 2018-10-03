using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.ViewModels
{
    public enum LocationDrawData { Department, Building }
    public class LocationViewModel
    {
        public LocationDrawData LocationDrawData { get; set; }
    }
}
