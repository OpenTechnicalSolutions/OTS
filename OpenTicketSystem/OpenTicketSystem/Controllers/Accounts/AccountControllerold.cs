using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpenTicketSystem.Models.Users;
using OpenTicketSystem.Repositories.LocationRepositories;
using OpenTicketSystem.Repositories.UserRepositories;
using OpenTicketSystem.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem.Controllers.Accounts
{
    public class AccountControllerold : Controller
    {
        private SignInManager<AppIdentityUser> _signInManager;
        private UserManager<AppIdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountControllerold(SignInManager<AppIdentityUser> signInManager, UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //[Authorize("AccountManager")]
        public IActionResult Index()
        {
            List<AppIdentityUser> userPreviewDetails = _userManager.Users.ToList();

            return View(userPreviewDetails);
        }
        //[Authorize("AccountManager")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize("AccountManager")]
        public async Task<IActionResult> Create(UserEditViewModel userEditViewModel)
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
        //[Authorize("AccountManager")]
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
           // var vm = GetViewModel();
            //vm.IdentityUser = user;
            if (user == null)
                RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize("AccountManager")]
        public async Task<IActionResult> Edit(UserEditViewModel uevm)
        {
            await _userManager.UpdateAsync(uevm.IdentityUser);
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("","Username/Password not found.");
            return View(loginViewModel);
        }
    }
}