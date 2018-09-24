using Microsoft.AspNetCore.Identity;
using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem
{
    public static class AccountDataInitializer
    {
        public static void SeedUsersAndRoles(UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUser(userManager);
        }

        public static void SeedUser(UserManager<AppIdentityUser> userManager)
        {
            if (userManager.Users.Any())
                return;
            
            var appIdUser = new AppIdentityUser { UserName = "Admin" };

            userManager.CreateAsync(appIdUser, "Changeme7!").Wait();
            userManager.AddToRolesAsync(appIdUser, new string[] {
                    "AccountManager",
                    "LocationManager"
            }).Wait();
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.Roles.Any())
                return;

            var roleList = new[]
            {
                new IdentityRole("AccountManager"),
                new IdentityRole("LocationManager"),
                new IdentityRole("TechnicianRoleManager"),
                new IdentityRole("Technician"),
                new IdentityRole("TechnicalManager"),
                new IdentityRole("TechnicalDirectory"),
                new IdentityRole("Customer"),
            };

            foreach (var ir in roleList)
                roleManager.CreateAsync(ir).Wait();
        }
    }
}
