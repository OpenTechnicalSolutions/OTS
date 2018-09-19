using Microsoft.AspNetCore.Identity;
using OpenTicketSystem.Models;
using OpenTicketSystem.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTicketSystem
{
    public class DefaultAccountSeeder
    {
        public static async void Seed(UserManager<AppIdentityUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                await userManager.CreateAsync(new AppIdentityUser
                {
                    UserName = "Administrator"
                }, "changeme");
            }
        }
    }
}
