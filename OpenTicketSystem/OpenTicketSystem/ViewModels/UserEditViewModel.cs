using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.ViewModels
{
    public class UserEditViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public int OfficeBuildingId { get; set; }
        public int OfficeRoomId { get; set; }
        public int TechnicalGroupId { get; set; }
        public int SubTechnicalGroupId { get; set; }
    }
}
