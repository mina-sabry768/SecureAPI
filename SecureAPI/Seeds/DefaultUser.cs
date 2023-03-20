using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Security.Claims;
using SecureAPI.DTO;

namespace Infarstuructre.Seeds
{
    public static class DefaultUser
    {
        

        public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefaultUser = new ApplicationUser
            {
                UserName = "RegularUser@domin.com",
                Email = "RegularUser@domin.com",
                Name = "RegularUser",
                EmailConfirmed = true
            };
            var User = userManager.FindByEmailAsync(DefaultUser.Email);
            if (User.Result == null)
            {
                await userManager.CreateAsync(DefaultUser, "RegularUser@P@$$w0rd123456");
                await userManager.AddToRolesAsync(DefaultUser, new List<string> { "RegularUser" });

            }
        }

        public static async Task SeedUserManagerAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefaultUser = new ApplicationUser
            {
                UserName = "UserManager@domin.com",
                Email = "UserManager@domin.com",
                Name = "UserManager",
                EmailConfirmed = true
            };
            var user = await userManager.FindByEmailAsync(DefaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(DefaultUser, "UserManager@P@$$w0rd123456");
                await userManager.AddToRolesAsync(DefaultUser, new List<string> { "UserManager" });

            }
        }


        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefaultUser = new ApplicationUser
            {
                UserName = "admin@domin.com",
                Email = "admin@domin.com",
                Name = "Admin",
                EmailConfirmed = true
            };
            var user = await userManager.FindByEmailAsync(DefaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(DefaultUser, "admin@P@$$w0rd123456");
                await userManager.AddToRolesAsync(DefaultUser, new List<string> { "Admin" });

            }
        }
    }
}
