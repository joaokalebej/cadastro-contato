namespace CadastroContatos.ViewModel;

public class ConsultaContatosViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Empresa { get; set; }
    public string Emails { get; set; }
    public string TelefonePessoal { get; set; }
    public string TelefoneComercial { get; set; }
    public DateTime DataInclusao { get; set; }
}