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
    public class RepositorioProduto : RepositorioBase<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(ApplicationDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<Produto> BuscarProdutoComCategoriaPeloId(int id)
        {
            var produto = await _context.Set<Produto>()
                .Include(x => x.Categoria)
                .Include(p => p.Categoria.Produtos)
                .FirstOrDefaultAsync(x => x.Id == id);

            return produto;
        }

    }
}
