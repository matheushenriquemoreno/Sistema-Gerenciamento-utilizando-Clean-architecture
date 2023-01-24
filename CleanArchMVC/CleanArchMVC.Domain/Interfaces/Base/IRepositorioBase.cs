using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Domain.Entities.Base;

namespace CleanArchMVC.Domain.Interfaces.Base;

public interface IRepositorioBase<T> where T : IEntidadeBase
{
    Task<IEnumerable<T>> ObterTodosAsync();
    Task<T> ObterPorIdAsync(int id);
    IQueryable<T> ObterTodosLazy();
    Task<T> Adicionar(T entidade);
    Task<T> Update(T entidade);
    Task Remover(T entidade);
    Task Salvar();
}

