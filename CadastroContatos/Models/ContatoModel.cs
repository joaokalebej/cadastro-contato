using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroContatos.Models;

[Table("contatos")]
public class ContatoModel
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Empresa { get; set; }
    public string TelefoneComercial { get; set; }
    public string TelefonePessoal { get; set; }
    public DateTime DataInclusao { get; set; }
    public List<ContatoEmailModel> Emails { get; set; } = new();
}