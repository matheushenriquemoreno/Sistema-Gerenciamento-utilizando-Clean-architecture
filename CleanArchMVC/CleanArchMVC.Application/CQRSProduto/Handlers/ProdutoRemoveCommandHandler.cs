using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Application.Produtos.Commands;
using CleanArchMVC.Domain.Interfaces;
using MediatR;

namespace CleanArchMVC.Application.CQRSProduto.Handlers
{
    public class ProdutoRemoveCommandHandler : IRequestHandler<ProdutoRemoveCommand, bool>
    {
        private readonly IRepositorioProduto repositorioProduto;

        public ProdutoRemoveCommandHandler(IRepositorioProduto repositorioProduto)
        {
            this.repositorioProduto = repositorioProduto;
        }


        public async Task<bool> Handle(ProdutoRemoveCommand request, CancellationToken cancellationToken)
        {
            var produto = await repositorioProduto.ObterPorIdAsync(request.Id);

            if (produto == null) { throw new ArgumentNullException("Produto não Existente"); }

            await repositorioProduto.Remover(produto);

            return true;
        }
    }
}
