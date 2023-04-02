using System.ComponentModel.DataAnnotations;
using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Application.DTOS
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome e obrigatorio")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        public IEnumerable<ProdutoDTO> Produtos { get; set; }
    }
}
