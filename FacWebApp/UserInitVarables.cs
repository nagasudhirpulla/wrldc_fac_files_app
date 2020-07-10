using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacWebApp
{
    public class UserInitVariables
    {
        public string GuestEmail { get; set; }
        public string GuestPassword { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string GuestUserName { get; set; } = "guest";
        public string AdminUserName { get; set; } = "admin";
        public string SurchargeUserName { get; set; } = "surchargeGuest";
        public string SurchargeEmail { get; set; }
        public string SurchargePassword { get; set; }

        public void InitializeFromConfig(IConfiguration Configuration)
        {
            GuestEmail = Configuration["IdentityInit:GuestEmail"];
            GuestPassword = Configuration["IdentityInit:GuestPassword"];
            AdminEmail = Configuration["IdentityInit:AdminEmail"];
            AdminPassword = Configuration["IdentityInit:AdminPassword"];
            GuestUserName = Configuration["IdentityInit:GuestUserName"];
            AdminUserName = Configuration["IdentityInit:AdminUserName"];
            SurchargeUserName = Configuration["IdentityInit:SurchargeUserName"];
            SurchargeEmail = Configuration["IdentityInit:SurchargeEmail"];
            SurchargePassword = Configuration["IdentityInit:SurchargePassword"];
        }
    }
}
