using CleanArchMVC.Domain.Interfaces.Base;
using CleanArchMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace CleanArchMVC.Infra.Data.Repositorios.Base
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class, IEntidadeBase
    {

        protected readonly DbContext _context;

        public RepositorioBase(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public DbSet<T> Entidade() => _context.Set<T>();

        public async Task<T> Adicionar(T entidade)
        {
            await Entidade().AddAsync(entidade);
            await Salvar();
            return entidade;
        }

        public virtual async Task<T> ObterPorIdAsync(int id)
        {
            return await Entidade().FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public IQueryable<T> ObterTodosLazy()
        {
            return Entidade().AsQueryable();
        }

        public async Task<IEnumerable<T>> ObterTodosAsync()
        {
            return await Entidade().AsNoTracking().ToListAsync();
        }

        public async Task Remover(T entidade)
        {
            _context.Remove(entidade);
            await Salvar();
        }

        public async Task<T> Update(T entidade)
        {
            Entidade().Update(entidade);
            await Salvar();
            return entidade;
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
