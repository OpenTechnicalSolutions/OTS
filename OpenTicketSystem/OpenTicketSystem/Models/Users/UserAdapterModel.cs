using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models.Users
{
    public class UserAdapterModel
    {
        public AppIdentityUser _identityUser;

        public int Id { get; set; }
        public string UserId { get => _identityUser.Id; }
        public string UserName { get => _identityUser.UserName; set => _identityUser.UserName = value; }
        public string FirstName { get => _identityUser.FirstName; set => _identityUser.FirstName = value; }
        public string LastName { get => _identityUser.LastName; set => _identityUser.LastName = value; }
        public string Email { get => _identityUser.Email; set => _identityUser.Email = value; }
        public string PhoneNumber { get => _identityUser.PhoneNumber; set => _identityUser.PhoneNumber = value; }
        public int? DepartmentId { get => _identityUser.DepartmentId.Value; set => _identityUser.DepartmentId = value; }
        public int? OfficeBuildingId { get => _identityUser.OfficeBuildingId.Value; set => _identityUser.OfficeBuildingId = value; }
        public int? OfficeRoomId { get => _identityUser.OfficeRoomId.Value; set => _identityUser.OfficeRoomId = value; }
        public int? TechnicalGroupId { get => _identityUser.TechnicalGroupId.Value; set => _identityUser.TechnicalGroupId = value; }
        public int? SubTechnicalGroupId { get => _identityUser.SubTechnicalGroupId.Value; set => _identityUser.SubTechnicalGroupId = value; }

    }
}
