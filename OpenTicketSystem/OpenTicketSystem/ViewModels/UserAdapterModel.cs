using OpenTicketSystem.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.ViewModels
{
    public class UserAdapterModel
    {
        public AppIdentityUser _identityUser;

        public int Id { get; set; }
        public string UserId { get => _identityUser.Id; }
        [Required]
        [StringLength(100,ErrorMessage = "User name is required.")]
        [Display(Name = "User Name")]
        public string UserName { get => _identityUser.UserName; set => _identityUser.UserName = value; }
        [Required]
        [StringLength(100, ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get => _identityUser.FirstName; set => _identityUser.FirstName = value; }
        [Required]
        [StringLength(100, ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get => _identityUser.LastName; set => _identityUser.LastName = value; }
        [Required]
        [StringLength(100, ErrorMessage = "Your email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get => _identityUser.Email; set => _identityUser.Email = value; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "The phone number is not entered in a correct format")]
        public string PhoneNumber { get => _identityUser.PhoneNumber; set => _identityUser.PhoneNumber = value; }
        public int? DepartmentId { get => _identityUser.DepartmentId; set => _identityUser.DepartmentId = value; }
        public int? OfficeBuildingId { get => _identityUser.OfficeBuildingId; set => _identityUser.OfficeBuildingId = value; }
        public int? OfficeRoomId { get => _identityUser.OfficeRoomId; set => _identityUser.OfficeRoomId = value; }
        public int? TechnicalGroupId { get => _identityUser.TechnicalGroupId; set => _identityUser.TechnicalGroupId = value; }
        public int? SubTechnicalGroupId { get => _identityUser.SubTechnicalGroupId; set => _identityUser.SubTechnicalGroupId = value; }
        [Required]
        [DataType(DataType.Password)]
        public string Password1 { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password2 { get; set; }

        public UserAdapterModel()
        { }

        public UserAdapterModel(AppIdentityUser identityUser)
        {
            _identityUser = identityUser;
        }
    }
}
