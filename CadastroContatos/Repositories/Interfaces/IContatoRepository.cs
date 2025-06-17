using CadastroContatos.Models;

namespace CadastroContatos.Repositories.Interfaces;

public interface IContatoRepository
{
    List<ContatoModel> GetAll();
    ContatoModel GetById(int id);
    void Add(ContatoModel contato);
    void Update(ContatoModel contato);
    void Delete(int id);
}