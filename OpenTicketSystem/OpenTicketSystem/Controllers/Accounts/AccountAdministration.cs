using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Tickets;
using OpenTicketSystem.Models.Users;
using OpenTicketSystem.Repositories;
using OpenTicketSystem.Repositories.LocationRepositories;
using OpenTicketSystem.Repositories.UserRepositories;
using OpenTicketSystem.ViewModels;

namespace OpenTicketSystem.Controllers.Accounts
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
            List<AppIdentityUser> userPreviewDetails = _userManager.Users.ToList();

            return View(userPreviewDetails);
        }

        public IActionResult CreateUser()
        {
            return View(GetViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserEditViewModel userEditViewModel)
        {
            if(ModelState.IsValid)
            {
                var user = userEditViewModel.IdentityUser;
                user.UserName = user.Email;
                var result = await _userManager.CreateAsync(user, userEditViewModel.Password);
                if(result.Succeeded)
                    return RedirectToAction("Index");

                return View(userEditViewModel);
            }
            return View(userEditViewModel);
        }

        public async Task<IActionResult> EditUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var vm = GetViewModel();
            vm.IdentityUser = user;
            if (user == null)
                RedirectToAction("Index");
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserEditViewModel uevm)
        {
            await _userManager.UpdateAsync(uevm.IdentityUser);
            return RedirectToAction("Index");
        }

        #region Not Controllers
        private UserEditViewModel GetViewModel()
        {
            var euvm = new UserEditViewModel
            {
                Roles = new List<SelectListItem>(),
                TechnicalGroups = new List<SelectListItem>(),
                SubTechnicalGroups = new List<SelectListItem>(),
                Departments = new List<SelectListItem>(),
                Buildings = new List<SelectListItem>(),
                Rooms = new List<SelectListItem>()
            };

            _roleManager.Roles.ToList().ForEach(r => euvm.Roles.Add(new SelectListItem { Value = r.Id, Text = r.Name }));
            _technicalGroupRepository.GetAll().ToList().ForEach(tg => euvm.TechnicalGroups.Add(new SelectListItem { Value = tg.Id.ToString(), Text = tg.Name }));
            _subTechnicalGroupRepository.GetAll().ToList().ForEach(stg => euvm.SubTechnicalGroups.Add(new SelectListItem { Value = stg.Id.ToString(), Text = stg.Name }));
            _departmentRepository.GetAll().ToList().ForEach(d => euvm.Departments.Add(new SelectListItem { Value = d.Id.ToString(), Text = d.Name }));
            _buildingRepository.GetAll().ToList().ForEach(b => euvm.Buildings.Add(new SelectListItem { Value = b.Id.ToString(), Text = b.Name }));
            _roomRepository.GetAll().ToList().ForEach(r => euvm.Rooms.Add(new SelectListItem { Value = r.Id.ToString(), Text = r.Name }));

            return euvm;
        }
       /* private AppIdentityUser ViewModelToIdentityUser(UserEditViewModel uevm)
        {
            var user = new AppIdentityUser()
            {
                UserName = uevm.Email,
                Email = uevm.Email,
                PhoneNumber = uevm.PhoneNumber,
                FirstName = uevm.FirstName,
                LastName = uevm.LastName,
                DepartmentId = uevm.DepartmentId.Value,
                OfficeBuildingId = uevm.OfficeBuildingId.Value,
                OfficeRoomId = uevm.OfficeRoomId.Value,
                TechnicalGroupId = uevm.TechnicalGroupId.Value,
                SubTechnicalGroupId = uevm.SubTechnicalGroupId.Value
            };

            return user;
        }
        private UserEditViewModel IdentityUserToViewModel(AppIdentityUser user)
        {
            var vm = GetViewModel();
            vm.UserId = user.Id;
            vm.Email = user.Email;
            vm.PhoneNumber = user.PhoneNumber;
            vm.FirstName = user.FirstName;
            vm.LastName = user.LastName;
            vm.DepartmentId = user.DepartmentId;
            vm.OfficeBuildingId = user.OfficeBuildingId;
            vm.OfficeRoomId = user.OfficeRoomId;
            vm.TechnicalGroupId = user.TechnicalGroupId;
            vm.SubTechnicalGroupId = user.SubTechnicalGroupId;

            return vm;
        }*/
        #endregion
    }
}