using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacWebApp
{
    public static class AppIdentityDataInitializer
    {
        private static readonly string GuestUserRoleString = "GuestUser";
        private static readonly string AdministratorRoleString = "Administrator";

        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration Configuration)
        {
            UserInitVariables initVariables = new UserInitVariables();
            initVariables.InitializeFromConfig(Configuration);
            SeedUserRoles(roleManager);
            SeedGuestAdminUsers(userManager, initVariables);
        }

        public static void SeedGuestAdminUsers(UserManager<IdentityUser> userManager, UserInitVariables initVariables)
        {
            string GuestUserName = initVariables.GuestUserName;
            string GuestEmail = initVariables.GuestEmail;
            string GuestPassword = initVariables.GuestPassword;
            string AdminUserName = initVariables.AdminUserName;
            string AdminEmail = initVariables.AdminEmail;
            string AdminPassword = initVariables.AdminPassword;
            if (userManager.FindByNameAsync(GuestUserName).Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = GuestUserName,
                    Email = GuestEmail
                };

                IdentityResult result = userManager.CreateAsync(user, GuestPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, GuestUserRoleString).Wait();
                }
            }


            if (userManager.FindByNameAsync(AdminUserName).Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = AdminUserName,
                    Email = AdminEmail
                };

                IdentityResult result = userManager.CreateAsync(user, AdminPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, AdministratorRoleString).Wait();
                }
            }
        }

        public static void SeedUserRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(GuestUserRoleString).Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = GuestUserRoleString,
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync(AdministratorRoleString).Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = AdministratorRoleString,
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
