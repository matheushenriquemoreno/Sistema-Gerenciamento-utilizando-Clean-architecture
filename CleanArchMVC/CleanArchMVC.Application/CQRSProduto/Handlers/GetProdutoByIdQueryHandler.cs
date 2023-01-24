using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Application.Produtos.Queries;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;

namespace CleanArchMVC.Application.CQRSProduto.Handlers
{
    public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, Produto>
    {
        private readonly IRepositorioProduto repositorioProduto;

        public GetProdutoByIdQueryHandler(IRepositorioProduto repositorioProduto)
        {
            this.repositorioProduto = repositorioProduto;
        }

        public async Task<Produto> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            return await repositorioProduto.BuscarProdutoComCategoriaPeloId(request.Id);
        }
    }
}
