using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Domain.Account;
using CleanArchMVC.Infra.Data.Identity.Enums;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMVC.Infra.Data.Identity.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<AplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SeedUserRoleInitial(UserManager<AplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if(userManager.FindByEmailAsync("matheus@teste.com").Result is null)
            {
                AplicationUser user = new AplicationUser
                {
                    UserName = "matheus@teste.com",
                    Email = "matheus@teste.com",
                    EmailConfirmed= true,
                    LockoutEnabled=false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = userManager.CreateAsync(user, "Senha1234#").Result;

                userManager.AddToRoleAsync(user, "User").Wait();
            }

            if (userManager.FindByEmailAsync("admin@teste.com").Result is null)
            {
                AplicationUser user = new AplicationUser
                {
                    UserName = "admin@teste.com",
                    Email = "admin@teste.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = userManager.CreateAsync(user, "Senha1234#").Result;

                userManager.AddToRoleAsync(user, "Admin").Wait();
            }

        }

        public void SeedUsers()
        {
            if (!roleManager.RoleExistsAsync(RoleSistem.User.ToString()).Result)
            {
                var role = new IdentityRole
                {
                    Name = RoleSistem.User.ToString(),
                    NormalizedName = RoleSistem.User.ToString().ToUpper(),
                };

                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync(RoleSistem.Admin.ToString()).Result)
            {
                var role = new IdentityRole
                {
                    Name = RoleSistem.Admin.ToString(),
                    NormalizedName = RoleSistem.Admin.ToString().ToUpper(),
                };

                roleManager.CreateAsync(role).Wait();
            }

        }
    }
}
