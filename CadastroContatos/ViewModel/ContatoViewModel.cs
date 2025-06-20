using System.ComponentModel.DataAnnotations;

namespace CadastroContatos.ViewModel;

public class ContatoViewModel
{
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        public string Empresa { get; set; }
        public DateTime DataInclusao { get; set; }

        public List<string> Emails { get; set; } = new();

        [Display (Name = "Telefone Pessoal")]
        public string TelefonePessoal { get; set; }

        [Display (Name = "Telefone Comercial")]
        public string TelefoneComercial { get; set; }
}