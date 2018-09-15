using Microsoft.AspNetCore.Identity;
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
        public List<IdentityRole> Roles { get; set; }
        public List<TechnicalGroup> TechnicalGroups { get; set; }
        public List<SubTechnicalGroup> SubTechnicalGroups { get; set; }
        public List<DepartmentModel> Departments { get; set; }
        public List<Building> Buildings { get; set; }
        public List<Room> Rooms { get; set; }

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
