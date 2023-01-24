using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces.Base;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface IRepositorioProduto : IRepositorioBase<Produto>
    {
        Task<Produto> BuscarProdutoComCategoriaPeloId(int id);

    }
}
