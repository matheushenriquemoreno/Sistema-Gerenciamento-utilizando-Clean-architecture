using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Application.Produtos.Commands;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;

namespace CleanArchMVC.Application.CQRSProduto.Handlers
{
    internal class ProdutoUpdateCommandHandler : IRequestHandler<ProdutoUpdateCommand, Produto>
    {
        private readonly IRepositorioProduto repositorioProduto;
        private readonly IRepositorioCategoria repositorioCategoria;

        public ProdutoUpdateCommandHandler(IRepositorioProduto repositorioProduto, IRepositorioCategoria repositorioCategoria)
        {
            this.repositorioProduto = repositorioProduto;
            this.repositorioCategoria = repositorioCategoria;
        }

        public async Task<Produto> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            var produto = await repositorioProduto.ObterPorIdAsync(request.Id);

            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            var categoria = await repositorioCategoria.ObterPorIdAsync(request.Id);

            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            produto.Atualizar(request.Nome, request.Descricao, request.Preco, request.Estoque, request.Image, categoria);

            return await repositorioProduto.Update(produto);
        }
    }
}
