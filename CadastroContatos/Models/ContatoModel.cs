using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroContatos.Models;

[Table("contatos")]
public class ContatoModel
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int TelefoneComercial { get; set; }
    public int TelefonePessoal { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public bool Excluir { get; set; }
}