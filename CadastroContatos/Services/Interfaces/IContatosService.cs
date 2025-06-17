using CadastroContatos.Models;

namespace CadastroContatos.Services.Interfaces;

public interface IContatosService
{
    List<ContatoModel> GetAllContatos();
    ContatoModel GetContatoById(int id);
}