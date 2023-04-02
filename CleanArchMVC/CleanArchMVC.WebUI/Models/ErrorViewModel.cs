namespace CleanArchMVC.WebUI.Models
{
    public class ErrorViewModel
    {
        public string? MensagemDeErro { get; set; }

        public bool ExisteMensagemDeErro => !string.IsNullOrEmpty(MensagemDeErro);
    }
}