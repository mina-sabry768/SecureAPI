
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.Seeds
{
    public static class DefultRole
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            //if (!roleManager.Roles.Any())
            //{
                await roleManager.CreateAsync(new IdentityRole("RegularUser"));
                await roleManager.CreateAsync(new IdentityRole("UserManager"));
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            //}

        }

    }
}
