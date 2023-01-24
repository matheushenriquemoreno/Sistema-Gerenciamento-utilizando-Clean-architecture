using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Domain.Entities;
using MediatR;

namespace CleanArchMVC.Application.Produtos.Commands
{
    public class ProdutoRemoveCommand : IRequest<bool>
    {
        public int Id { get;  private set; }

        public ProdutoRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
