using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Application.DTOS
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome e obrigatorio")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição e obrigatorio")]
        [MinLength(3)]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preço obrigatorio")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency, ErrorMessage = "Valor digitado não e valido")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Estoque obrigatorio")]
        [Range(1,9999, ErrorMessage = "teste")]
        public int Estoque { get; set; }

        [Required(ErrorMessage = "Imagem obrigatorio")]
        public string Image { get; set; }

        [Required]
        public int? IdCategoria { get; set; }

        public Categoria Categoria { get; set; }

    }
}
