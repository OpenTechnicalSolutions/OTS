using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenTicketSystem.Controllers.Home;
using OpenTicketSystem.Models.Users;
using OpenTicketSystem.ViewModels;

namespace OpenTicketSystem.Controllers.Accounts
{
    public class AccountController : Controller
    {
        private SignInManager<AppIdentityUser> _signInManager;
        private UserManager<AppIdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<AppIdentityUser> signInManager, UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        // GET: AppAccount
        public ActionResult Index()
        {
            return PartialView(_userManager.Users.ToList());
        }

        // GET: AppAccount/Details/5
        public ActionResult Details(string id)
        {
            return View(_userManager.Users.FirstOrDefault(u => u.Id == id));
        }

        // GET: AppAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppAccount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserViewModel createUserViewModel)
        {
            if (!ModelState.IsValid)
                return View(createUserViewModel);

            if(createUserViewModel.Password != createUserViewModel.Password2)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View(createUserViewModel);
            }

            try
            {
                // TODO: Add insert logic here
                await _userManager.CreateAsync(createUserViewModel.IdentityUser, createUserViewModel.Password);
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
            var user = _userManager.Users.First(u => u.Id == id);

            var create = new CreateUserViewModel
            {
                IdentityUser = user
            };

            return View(create);
        }

        // POST: AppAccount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateUserViewModel createUserViewModel)
        {
            try
            {
                // TODO: Add update logic here
                await _userManager.UpdateAsync(createUserViewModel.IdentityUser);
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

            var create = new CreateUserViewModel
            {
                IdentityUser = user
            };

            return View(create);
        }

        // POST: AppAccount/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CreateUserViewModel createUserViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                _userManager.DeleteAsync(createUserViewModel.IdentityUser);
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
                return RedirectToAction(nameof(Index), nameof(HomeController));

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