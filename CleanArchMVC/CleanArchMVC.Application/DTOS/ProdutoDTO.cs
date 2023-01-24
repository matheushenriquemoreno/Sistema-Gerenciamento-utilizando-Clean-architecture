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

        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required]
        [Range(1,9999)]
        public int Estoque { get; set; }
        [Required]
        public string Image { get; set; }

        [Required]
        public int IdCategoria { get; set; }


        public Categoria Categoria { get; set; }

    }
}
