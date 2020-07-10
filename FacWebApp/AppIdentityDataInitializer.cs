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
        public static readonly string GuestUserRoleString = "GuestUser";
        public static readonly string AdministratorRoleString = "Administrator";
        public static readonly string SurchargeRoleString = "SurchargeUser";

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
            string SurchargeUserName = initVariables.SurchargeUserName;
            string SurchargeEmail = initVariables.SurchargeEmail;
            string SurchargePassword = initVariables.SurchargePassword;

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


            if (userManager.FindByNameAsync(SurchargeUserName).Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = SurchargeUserName,
                    Email = SurchargeEmail
                };

                IdentityResult result = userManager.CreateAsync(user, SurchargePassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, SurchargeRoleString).Wait();
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

            if (!roleManager.RoleExistsAsync(SurchargeRoleString).Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = SurchargeRoleString,
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
