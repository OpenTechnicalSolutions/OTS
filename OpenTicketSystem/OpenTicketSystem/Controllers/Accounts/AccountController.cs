using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Controllers.Home;
using OpenTicketSystem.Models.Locations;
using OpenTicketSystem.Models.Users;
using OpenTicketSystem.Repositories.LocationRepositories;
using OpenTicketSystem.Repositories.UserRepositories;
using OpenTicketSystem.ViewModels;

namespace OpenTicketSystem.Controllers.Accounts
{
    public class AccountController : Controller
    {
        private SignInManager<AppIdentityUser> _signInManager;
        private UserManager<AppIdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private DepartmentRepository _departmentRepository;
        private BuildingRepository _buildingRepository;
        private TechnicalGroupRepository _technicalGroupRepository;
        private RoomRepository _roomRepository;
        private SubTechnicalGroupRepository _subTechnicalGroupRepository;

        public AccountController(SignInManager<AppIdentityUser> signInManager, 
            UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager, 
            DepartmentRepository departmentRepository, BuildingRepository buildingRepository,
            TechnicalGroupRepository technicalGroupRepository, RoomRepository roomRepository, 
            SubTechnicalGroupRepository subTechnicalGroupRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _departmentRepository = departmentRepository;
            _buildingRepository = buildingRepository;
            _technicalGroupRepository = technicalGroupRepository;
            _roomRepository = roomRepository;
            _subTechnicalGroupRepository = subTechnicalGroupRepository;
        }

        // GET: AppAccount
        public ActionResult Index()
        {
            var adapterList = new List<UserAdapterModel>();
            var userList = _userManager.Users.ToList();
            foreach(var user in userList)           
                adapterList.Add(new UserAdapterModel(user));            
            return View(adapterList);
        }

        // GET: AppAccount/Details/5
        public ActionResult Details(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            var adapter = new UserAdapterModel(user);
            adapter.Departments = new List<DepartmentModel> { _departmentRepository.GetById(user.DepartmentId.Value) };
            adapter.Buildings = new List<Building> { _buildingRepository.GetById(user.OfficeBuildingId.Value) };
            adapter.Rooms = new List<Room> { _roomRepository.GetById(user.OfficeRoomId.Value) };
            adapter.TechnicalGroups = new List<TechnicalGroup> { _technicalGroupRepository.GetById(user.TechnicalGroupId.Value) };
            adapter.SubTechnicalGroups = new List<SubTechnicalGroup> { _subTechnicalGroupRepository.GetById(user.SubTechnicalGroupId.Value) };
            return View(adapter);
        }

        // GET: AppAccount/Create
        public ActionResult Create()
        {
            var adapter = new UserAdapterModel(new AppIdentityUser());
            adapter.Departments = _departmentRepository.GetAll().ToList();
            adapter.Buildings = _buildingRepository.GetAll().ToList();
            adapter.TechnicalGroups = _technicalGroupRepository.GetAll().ToList();
            return View(adapter);
        }

        // POST: AppAccount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserAdapterModel adapter)
        {
            if (!ModelState.IsValid)
                return View(adapter);

            if(adapter.Password1 != adapter.Password2)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View(adapter);
            }

            try
            {
                await _userManager.CreateAsync(adapter._identityUser, adapter.Password1);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppAccount/Edit/5
        public ActionResult Edit(string id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
            var adapter = new UserAdapterModel(user);
            
            return View(user);
        }

        // POST: AppAccount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserAdapterModel createUserViewModel)
        {
            try
            {
                await _userManager.UpdateAsync(createUserViewModel._identityUser);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppAccount/Delete/5
        public ActionResult Delete(string id)
        {
            var user = _userManager.Users.First(u => u.Id == id);
            var adapter = new UserAdapterModel(user);
            
            return View(adapter);
        }

        // POST: AppAccount/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string UserId, IFormCollection fc)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == UserId);
            try
            {
                // TODO: Add delete logic here
                _userManager.DeleteAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if(user == null)
            {
                ModelState.AddModelError("","Username/Password do not match");
                return View(loginViewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password,false, false);
            if (result.Succeeded)
                return RedirectToAction(nameof(Index), "Home");

            return View(loginViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}