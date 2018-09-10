using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models.Users;
using OpenTicketSystem.ViewModels;

namespace OpenTicketSystem.Controllers
{
    public class AccountAdministrationController : Controller
    {
        public SignInManager<AppIdentityUser> _signInManager;
        public UserManager<AppIdentityUser> _userManager;
        public RoleManager<AppIdentityUser> _roleManager;

        public AccountAdministrationController(SignInManager<AppIdentityUser> signInManager, UserManager<AppIdentityUser> userManager, RoleManager<AppIdentityUser> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            List<UserPreviewDetailsViewModel> userPreviewDetails = new List<UserPreviewDetailsViewModel>();

            foreach(var u in _userManager.Users)
            {
                userPreviewDetails.Add(new UserPreviewDetailsViewModel
                {
                    ProfileId = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber
                });
            }

            return View(userPreviewDetails);
        }
    }
}