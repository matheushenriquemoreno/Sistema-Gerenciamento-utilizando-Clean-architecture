using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Application.DTOS;

namespace CleanArchMVC.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetCategorias();
        Task<CategoriaDTO> GetByIDCategoria(int id);
        Task Add(CategoriaDTO categoriaDTO);
        Task Update(CategoriaDTO categoriaDTO);
        Task Remove(int id);
    }
}
