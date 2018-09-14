using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Users;
using OpenTicketSystem.ViewModels;

namespace OpenTicketSystem.Controllers
{
    public class AccountAdministration : Controller
    {
        private SignInManager<AppIdentityUser> _signInManager;
        private UserManager<AppIdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        private AppDbContext _dbContext;

        public AccountAdministration(SignInManager<AppIdentityUser> signInManager, UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext dbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
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

        public IActionResult CreateUser()
        {
            var editUserViewModel = new UserEditViewModel
            {
                Roles = _roleManager.Roles.ToList(),
                TechnicalGroups = _dbContext.TechnicalGroups.G
            }

            return View();
        }
    }
}