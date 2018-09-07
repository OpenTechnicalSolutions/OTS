using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OpenTicketSystem.Models.Users
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppIdentityUser, IdentityRole>
    {
        public AppClaimsPrincipalFactory(UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) :
            base(userManager, roleManager, options)
        {

        }

        public async override Task<ClaimsPrincipal> CreateAsync(AppIdentityUser identityUser)
        {
            var principal = await base.CreateAsync(identityUser);

            if(identityUser.DepartmentId.HasValue)
            {
                ((ClaimsIdentity)principal.Identity).AddClaims(new[]
                {
                    new Claim(ClaimTypes.)
                });
            }
        }
    }
}
