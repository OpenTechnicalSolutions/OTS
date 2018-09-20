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

        public static async void SeedUser(UserManager<AppIdentityUser> userManager)
        {
            if (userManager.Users.Any())
                return;
            
            var appIdUser = new AppIdentityUser { UserName = "Admin" };

            var result = await userManager.CreateAsync( appIdUser, "Changeme7!");
            if (!result.Succeeded)
                throw new AccessViolationException("Unable to create administrative account.");

            result = await userManager.AddToRoleAsync(appIdUser, "AccountManager");
            if (!result.Succeeded)
                throw new AccessViolationException("Unable to add AccountManager role to user.");

            result = await userManager.AddToRoleAsync(appIdUser, "LocationManager");
            if(!result.Succeeded)
                throw new AccessViolationException("Unable to add LocationManager role to user.");
        }

        public async static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.Roles.Any())
                return;
            var roleList = new[]
            {
                new IdentityRole("AccountManager"),
                new IdentityRole("LocationManager"),
                new IdentityRole("Technician"),
                new IdentityRole("TechnicalManager"),
                new IdentityRole("TechnicalDirectory"),
                new IdentityRole("Customer"),
            };

            foreach(var ir in roleList)
            {
                var res = await roleManager.CreateAsync(ir);
                if (!res.Succeeded)
                    throw new AccessViolationException("Failed to create IdentityRole: " + ir.Name);
            }
        }
    }
}
