using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Domain.Entities;
using MediatR;

namespace CleanArchMVC.Application.Produtos.Commands
{
    public abstract class ProdutoCommand : IRequest<Produto>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Image { get; set; }
        public Categoria Categoria  { get; set; }
    }
}
