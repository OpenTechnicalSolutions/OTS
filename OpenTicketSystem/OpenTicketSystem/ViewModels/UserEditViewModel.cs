using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenTicketSystem.Models.Locations;
using OpenTicketSystem.Models.Tickets;
using OpenTicketSystem.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.ViewModels
{
    public class UserEditViewModel
    {
        public List<SelectListItem> Roles { get; set; }
        public List<SelectListItem> TechnicalGroups { get; set; }
        public List<SelectListItem> SubTechnicalGroups { get; set; }
        public List<SelectListItem> Departments { get; set; }
        public List<SelectListItem> Buildings { get; set; }
        public List<SelectListItem> Rooms { get; set; }

        public AppIdentityUser IdentityUser { get; set; }

        public string UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DepartmentId { get; set; }
        public int? OfficeBuildingId { get; set; }
        public int? OfficeRoomId { get; set; }
        public int? TechnicalGroupId { get; set; }
        public int? SubTechnicalGroupId { get; set; }
    }
}
