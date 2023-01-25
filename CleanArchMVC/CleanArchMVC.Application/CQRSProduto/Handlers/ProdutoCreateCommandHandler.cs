using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Application.Produtos.Commands;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;

namespace CleanArchMVC.Application.CQRSProduto.Handlers
{
    public class ProdutoCreateCommandHandler : IRequestHandler<ProdutoCreateCommand, Produto>
    {
        private readonly IRepositorioProduto repositorioProduto;
        private readonly IRepositorioCategoria repositorioCategoria;

        public ProdutoCreateCommandHandler(IRepositorioProduto repositorioProduto, IRepositorioCategoria repositorioCategoria)
        {
            this.repositorioProduto = repositorioProduto;
            this.repositorioCategoria = repositorioCategoria;
        }

        public async Task<Produto> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            var categoria = await repositorioCategoria.ObterPorIdAsync(request.IdCategoria);

            if (categoria == null) { throw new ArgumentNullException(nameof(categoria)); }

            var produto = new Produto(request.Nome, request.Descricao, request.Preco, request.Estoque, request.Image, categoria);

            return await repositorioProduto.Adicionar(produto);
        }
    }
}
