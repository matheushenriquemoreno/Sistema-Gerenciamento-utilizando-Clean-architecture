using AutoMapper;
using CleanArchMVC.Application.DTOS;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;

namespace CleanArchMVC.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IMapper _mapper;

        public CategoriaService(IRepositorioCategoria repositorioCategoria, IMapper mapper)
        {
            this._repositorioCategoria = repositorioCategoria;
            this._mapper = mapper;
        }

        public async Task Add(CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);

            await _repositorioCategoria.Adicionar(categoria);
        }

        public async Task<CategoriaDTO> GetByIDCategoria(int id)
        {
            var categoria = await _repositorioCategoria.ObterPorIdAsync(id);

            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categorias = await _repositorioCategoria.ObterTodosAsync();

            return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
        }

        public async Task Remove(int id)
        {
            var categoria = _repositorioCategoria.ObterPorIdAsync(id).Result;

            await _repositorioCategoria.Remover(categoria);
        }

        public async Task Update(CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);

            await _repositorioCategoria.Update(categoria);
        }
    }
}
