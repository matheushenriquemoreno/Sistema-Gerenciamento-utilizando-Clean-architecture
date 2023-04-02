using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email Obrigatorio")]
        [EmailAddress(ErrorMessage = "Formato de email invaldio!")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Senha pode ter de {2} ate o maximo de {1} caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string ReturnUrl { get; set; }
    }
}
