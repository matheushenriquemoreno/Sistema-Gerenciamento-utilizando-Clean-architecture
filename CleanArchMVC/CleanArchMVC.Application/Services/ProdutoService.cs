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
using CleanArchMVC.Application.Produtos.Commands;
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
        private readonly IMediator _mediator;
        private readonly ICategoriaService _categoriaService;

        public ProdutoService(IMapper mapper, IMediator mediator, ICategoriaService categoriaService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _categoriaService = categoriaService;
        }

        public async Task Add(ProdutoDTO produtoDTO)
        {
            var produtoCommand = _mapper.Map<ProdutoCreateCommand>(produtoDTO);

            var produtoAdicionado = await _mediator.Send(produtoCommand);

            await _mediator.Publish(new NotificarCriarProdutoNotification(JsonConvert.SerializeObject(produtoAdicionado, Formatting.Indented)));
        }

        public async Task<ProdutoDTO> GetProdutoByID(int id)
        {
            var queryBuscarProdutoQuery = new GetProdutoByIdQuery(id);

            var produto = await _mediator.Send(queryBuscarProdutoQuery);

            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtosQuery = new GetProdutosQuery();

            var produtos = await _mediator.Send(produtosQuery);

            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task Remove(int id)
        {
            var produtoCommand = new ProdutoRemoveCommand(id);

            await _mediator.Send(produtoCommand);
        }

        public async Task Update(ProdutoDTO produtoDTO)
        {
            var updateCommand = _mapper.Map<ProdutoUpdateCommand>(produtoDTO);

            await _mediator.Send(updateCommand);
        }
    }
}
