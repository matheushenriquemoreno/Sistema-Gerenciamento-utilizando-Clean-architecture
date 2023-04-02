using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Account
{
    public interface IAutentificate
    {
        Task<bool> Autentificar(string email, string password);
        Task<bool> RegistrarUser(string email, string password);
        Task Logout();
    }
}
