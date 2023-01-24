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
        public ProdutoUpdateCommandHandler(IRepositorioProduto repositorioProduto)
        {
            this.repositorioProduto = repositorioProduto;
        }

        public async Task<Produto> Handle(ProdutoUpdateCommand request, CancellationToken cancellationToken)
        {
            var produto = await repositorioProduto.ObterPorIdAsync(request.Id);

            if (produto == null)
                throw new ArgumentNullException(typeof(Produto).ToString());

            produto.Atualizar(request.Nome, request.Descricao, request.Preco, request.Estoque, request.Image, request.Categoria);

            return await repositorioProduto.Update(produto);
        }
    }
}
