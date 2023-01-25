using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Application.DTOS;

namespace CleanArchMVC.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutos();
        Task<ProdutoDTO> GetProdutoByID(int id);
        Task Add(ProdutoDTO categoriaDTO);
        Task Update(ProdutoDTO categoriaDTO);
        Task Remove(int id);


    }
}
