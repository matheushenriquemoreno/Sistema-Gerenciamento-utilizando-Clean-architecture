using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Validation;
using FluentAssertions;

namespace CleanArchMVC.Domain.Tests
{
    public class CategoriaTeste
    {
        [Fact]
        public void CriarCategoria_ValidarParametros_ResultadoValido()
        {

            var categoria = new Categoria(1, "Categoria valida");
            Action action = () => new Categoria(1, "Categoria valida");
            action.Should().NotThrow();
        }

        [Fact]
        public void CriarCategoria_ValidarParametros_ResultadoValido2()
        {
            Action action = () => new Categoria( "Categoria valida");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar categoria, teste erro passar valor vazio")]
        public void CriarCategoria_ValidarParametros_ResultadoError()
        {
            Action action = () => new Categoria(1, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome invalido, valor Requirido");
        }

        [Fact(DisplayName = "Criar categoria, teste erro passar valor null")]
        public void CriarCategoria_ValidarParametros_ResultadoError2()
        {
            Action action = () => new Categoria(1, null);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome invalido, valor Requirido");
        }


        [Fact(DisplayName = "Criar categoria, teste erro nome menor que 3 caracter")]
        public void CriarCategoria_ValidarParametros_ResultadoError3()
        {
            Action action = () => new Categoria(1, "12");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome invalido, minimo de 3 caracteres");
        }


    }
}