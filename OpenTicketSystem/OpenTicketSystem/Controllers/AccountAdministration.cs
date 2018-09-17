using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Tickets;
using OpenTicketSystem.Models.Users;
using OpenTicketSystem.Repositories;
using OpenTicketSystem.ViewModels;

namespace OpenTicketSystem.Controllers
{
    public class AccountAdministration : Controller
    {
        private SignInManager<AppIdentityUser> _signInManager;
        private UserManager<AppIdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        private DepartmentRepository _departmentRepository;
        private RoomRepository _roomRepository;
        private BuildingRepository _buildingRepository;
        private TechnicalGroupRepository _technicalGroupRepository;
        private SubTechnicalGroupRepository _subTechnicalGroupRepository;

        public AccountAdministration(SignInManager<AppIdentityUser> signInManager, UserManager<AppIdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager, DepartmentRepository departmentRepository, RoomRepository roomRepository,
            BuildingRepository buildingRepository, TechnicalGroupRepository technicalGroupRepository, SubTechnicalGroupRepository subTechnicalGroupRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _departmentRepository = departmentRepository;
            _roomRepository = roomRepository;
            _buildingRepository = buildingRepository;
            _technicalGroupRepository = technicalGroupRepository;
            _subTechnicalGroupRepository = subTechnicalGroupRepository;
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
                TechnicalGroups = _technicalGroupRepository.GetAll().ToList(),
                SubTechnicalGroups = _subTechnicalGroupRepository.GetAll().ToList(),
                Departments = _departmentRepository.GetAll().ToList(),
                Buildings = _buildingRepository.GetAll().ToList(),
                Rooms = _roomRepository.GetAll().ToList(),
            };

            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserEditViewModel userEditViewModel)
        {
            if(ModelState.IsValid)
            {
                var user = new AppIdentityUser()
                {
                    UserName = userEditViewModel.Email,
                    Email = userEditViewModel.Email,
                    PhoneNumber = userEditViewModel.PhoneNumber,
                    FirstName = userEditViewModel.FirstName,
                    LastName = userEditViewModel.LastName,
                    DepartmentId = userEditViewModel.DepartmentId.Value,
                    OfficeBuildingId = userEditViewModel.OfficeBuildingId.Value,
                    OfficeRoomId = userEditViewModel.OfficeRoomId.Value,
                    TechnicalGroupId = userEditViewModel.TechnicalGroupId.Value,
                    SubTechnicalGroupId = userEditViewModel.SubTechnicalGroupId.Value
                };

                var result = await _userManager.CreateAsync(user, userEditViewModel.Password);
                if(result.Succeeded)
                    return RedirectToAction("Index");

                return View(userEditViewModel);
            }
            return View();
        }
    }
}