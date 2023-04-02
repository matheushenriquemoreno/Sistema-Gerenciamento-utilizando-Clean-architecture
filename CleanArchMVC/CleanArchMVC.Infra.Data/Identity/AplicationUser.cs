using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMVC.Infra.Data.Identity
{
    public class AplicationUser : IdentityUser
    {
        public bool UsuarioAtivo { get; set; }
    }
}
