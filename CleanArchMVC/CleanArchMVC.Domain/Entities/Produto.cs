using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Domain.Entities.Base;
using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Produto : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public string Image { get; private set; }
        public Categoria Categoria { get; set; }

        private Produto()
        {

        }

        public Produto(string name, string descricao, decimal preco, int estoque, string image, Categoria categoria)
        {
            ValidationDomain(name, descricao, preco, estoque, image, categoria);
        }

        public void Atualizar(string name, string descricao, decimal preco, int estoque, string image, Categoria categoria)
        {
            ValidationDomain(name, descricao, preco, estoque, image, categoria);
        }

        private void ValidationDomain(string name, string descricao, decimal preco, int estoque, string image, Categoria categoria)
        {
            DomainExceptionValidation.VerificaStringVazia(name, "Nome não pode ser vazio");
            DomainExceptionValidation.VerificaStringVazia(descricao, "Descricao não pode ser vazia");
            DomainExceptionValidation.When(image?.Length > 250, "url da imagen muito Grande");
            DomainExceptionValidation.When(preco < 0, "preco não pode ser menor que zero");
            DomainExceptionValidation.When(estoque < 0, "estoque não pode ser menor que zero");
            DomainExceptionValidation.When(categoria is null, "Categoria do produto não pode ser vazia");

            Nome = name;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            Image = image;
            Categoria = categoria;
        }

    }
}
