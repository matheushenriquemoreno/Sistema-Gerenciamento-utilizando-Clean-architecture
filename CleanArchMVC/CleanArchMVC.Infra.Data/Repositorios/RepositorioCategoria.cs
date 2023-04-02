
using System.Linq.Expressions;
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

        public void teste<ToutraProperty>(List<Expression<Func<Categoria, IEnumerable<ToutraProperty>>>> expression) where ToutraProperty : class
        {
            var categoria = ObterTodosLazy();

            foreach (var include in expression) {

                categoria.Include(include);
            }

            var categorias = categoria.ToList();
        }


        public void teste2()
        {
            var lista = new List<Expression<Func<Categoria, IEnumerable<Produto>>>>();

            lista.Add(Categoria => Categoria.Produtos);

            teste<Produto>(lista);

        }


    }
}
