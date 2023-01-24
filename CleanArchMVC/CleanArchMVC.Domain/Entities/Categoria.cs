using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Domain.Entities.Base;
using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Categoria : EntidadeBase
    {
        public string Nome { get; private set; }
        public ICollection<Produto> Produtos { get;  private set; }

        private Categoria()
        {

        }

        public Categoria(int id, string name)
        {
            Id = id;
            ValidateEntiti(name);
        }

        public Categoria(string name)
        {
            ValidateEntiti(name);
        }

        private void ValidateEntiti(string name)
        {
            DomainExceptionValidation.VerificaStringVazia(name, "Nome invalido, valor Requirido");
            DomainExceptionValidation.When(name.Length < 3, "Nome invalido, minimo de 3 caracteres");

            Nome = name;
        }

        public void AlterarNome(string name) => ValidateEntiti(name);

        public void AdicionarProduto(Produto produto)
        {
            Produtos.Add(produto);
        }

    }
}
