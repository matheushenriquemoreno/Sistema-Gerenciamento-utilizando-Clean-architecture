using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using CleanArchMVC.Application.CQRSProduto.Commands;
using CleanArchMVC.Application.CQRSProduto.Handlers;
using CleanArchMVC.Application.DTOS;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Application.Produtos.Queries;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace CleanArchMVC.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _Mediator;

        public ProdutoService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _Mediator = mediator;
        }

        //public async Task Add(ProdutoDTO categoriaDTO)
        //{



        //    var produto = _mapper.Map<Produto>(categoriaDTO);

        //    await _repositorioProduto.Adicionar(produto);
        //}

        //public async Task<ProdutoDTO> GetProdutoAndCategoria(int id)
        //{
        //   var produto = await  _repositorioProduto.BuscarProdutoComCategoriaPeloId(id);

        //    return _mapper.Map<ProdutoDTO>(produto);
        //}

        //public async Task<ProdutoDTO> GetProdutoByID(int id)
        //{
        //    var produto = await _repositorioProduto.ObterPorIdAsync(id);

        //    return _mapper.Map<ProdutoDTO>(produto);
        //}

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtosQuery = new GetProdutosQuery();

            var produtos = await _Mediator.Send(produtosQuery);

            _Mediator.Publish(new NotificarCriarProdutoNotification(JsonConvert.SerializeObject(produtos, Formatting.Indented)));

            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task Remove(int id)
        {
            //var produto = _repositorioProduto.ObterPorIdAsync(id).Result;
            //await _repositorioProduto.Remover(produto);
        }

        public async Task Update(ProdutoDTO categoriaDTO)
        {
            var produto = _mapper.Map<Produto>(categoriaDTO);

            //await _repositorioProduto.Update(produto);
        }
    }
}
