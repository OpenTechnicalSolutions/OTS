using Microsoft.AspNetCore.Identity;
using OpenTicketSystem.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models.Users
{
    public class AppIdentityUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? OfficeBuildingId { get; set; }
        public int? OfficeRoomId { get; set; }
        public int? DepartmentId { get; set; }
        public int? SubDepartmentId { get; set; }
    }
}
