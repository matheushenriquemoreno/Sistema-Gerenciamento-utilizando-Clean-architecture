using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMVC.Application.DTOS;
using CleanArchMVC.Application.Produtos.Commands;

namespace CleanArchMVC.Application.Mapeamento
{
    public class MapeamentoDTOParaCommandsCQRS : Profile
    {
        public MapeamentoDTOParaCommandsCQRS()
        {
            CreateMap<ProdutoDTO, ProdutoCreateCommand>();
            CreateMap<ProdutoDTO, ProdutoUpdateCommand>();
        }
    }
}
