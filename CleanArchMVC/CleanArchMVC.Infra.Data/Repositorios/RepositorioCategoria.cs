using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Infra.Data.Repositorios.Base;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMVC.Infra.Data.Repositorios
{
    public class RepositorioCategoria : RepositorioBase<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(ApplicationDbContext dbContext) : base(dbContext)
        {
        }


        public override async Task<Categoria> ObterPorIdAsync(int id)
        {
            var categoria = await _context.Set<Categoria>()
                            .Include(x => x.Produtos)
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();

            return categoria;
        }

    }
}
