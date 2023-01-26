using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMVC.Application.DTOS;
using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Application.Mapeamento
{
    public class ConfigurandoMapeamentosProfile : Profile
    {
        public ConfigurandoMapeamentosProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().BeforeMap((p,d) => d.IdCategoria = p.Categoria?.Id ).ReverseMap();
        }
    }
}
