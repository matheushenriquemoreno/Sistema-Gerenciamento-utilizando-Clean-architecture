using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMVC.Infra.Data.Identity.Services
{
    public class AuthenticateService : IAutentificate
    {
        private readonly UserManager<AplicationUser> userManager;
        private readonly SignInManager<AplicationUser> loginManager;

        public AuthenticateService(UserManager<AplicationUser> userManager, SignInManager<AplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.loginManager = signInManager;
        }

        public async Task<bool> Autentificar(string email, string password)
        {
            var result = await loginManager.PasswordSignInAsync(email, password, false,lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await loginManager.SignOutAsync();
        }

        public async Task<bool> RegistrarUser(string email, string password)
        {
            var aplicationUser = new AplicationUser
            {
                UserName = email,
                Email= email,
                UsuarioAtivo = true
            };

            var result = await userManager.CreateAsync(aplicationUser, password);

            return result.Succeeded;
        }
    }
}
