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
        public static async Task<bool> SeedUsersAndRoles(UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedUser(userManager);
            return true;
        }

        public static async Task<bool> SeedUser(UserManager<AppIdentityUser> userManager)
        {
            if (userManager.Users.Any())
                return true;
            
            var appIdUser = new AppIdentityUser { UserName = "Admin" };

            await userManager.CreateAsync(appIdUser, "Changeme7!")
                .ContinueWith(async r => await userManager.AddToRolesAsync(appIdUser, new string[] {
                    "AccountManager",
                    "LocationManager"
            }));
            return true;

        }

        public static async Task<bool> SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.Roles.Any())
                return true;

            var roleList = new[]
            {
                new IdentityRole("AccountManager"),
                new IdentityRole("LocationManager"),
                new IdentityRole("Technician"),
                new IdentityRole("TechnicalManager"),
                new IdentityRole("TechnicalDirectory"),
                new IdentityRole("Customer"),
            };
          
            foreach (var ir in roleList)
               await roleManager.CreateAsync(ir);
            return true;
        }
    }
}
