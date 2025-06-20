using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroContatos.Models;

[Table("contatoemail")]
public class ContatoEmailModel
{
    [Key]
    public int Id { get; set; }
    public int ContatoId { get; set; }
    public string Email { get; set; } = string.Empty;
    public ContatoModel Contato { get; set; } = null!;
}