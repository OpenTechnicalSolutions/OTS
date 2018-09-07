using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models.Users
{
    public class AppIdentityUser : IdentityUser
    {
        public int? DepartmentId { get; set; }
        public int? SubDepartmentId { get; set; }
    }
}
