using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;
using FluentAssertions;

namespace CleanArchMVC.Domain.Tests
{
    public class ProdutoTeste
    {

        private Categoria _categoria = new Categoria(1, "Teste Produto");

        [Fact]
        public void CriarProduto_ValidarParametros_ResultadoValido()
        {
            Action action = () => new Produto("Teste", "Produto para teste", 100.00M, 10, "url Imagem Qualquer", _categoria);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CriarProduto_ValidarNomeVazio_ResultadoException()
        {
            Action action = () => new Produto("", "", 100.00M, 10, "url Imagem Qualquer", _categoria);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome não pode ser vazio");
        }

        [Fact]
        public void CriarProduto_ValidarPrecoNegativo_ResultadoException()
        {
            Action action = () => new Produto("Teste", "teste", -11, 10, "url Imagem Qualquer", _categoria);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("preco não pode ser menor que zero");
        }


        [Fact]
        public void CriarProduto_EstoqueValorNegativo_ResultadoException()
        {
            Action action = () => new Produto("Teste", "teste", 10, -1, "url Imagem Qualquer", _categoria);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("estoque não pode ser menor que zero");
        }


        [Fact]
        public void CriarProduto_ValidarImageNull_ResultadoException()
        {
            Action action = () => new Produto("Teste", "teste", 0.0m, 0, null, _categoria);

            action.Should().NotThrow();
        }

        [Fact]
        public void CriarProduto_ValidarCategoriaVazia_ResultadoException()
        {
            Action action = () => new Produto("Teste", "teste", 0.0m, 0, null, null);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Categoria do produto não pode ser vazia");
        }


    }
}
