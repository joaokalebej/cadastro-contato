using CadastroContatos.Models;
using CadastroContatos.ViewModel;

namespace CadastroContatos.Repositories.Interfaces;

public interface IContatoRepository
{
    IQueryable<ConsultaContatosViewModel> GetConsulta();
    ContatoModel GetById(int id);
    void Add(ContatoModel contato);
    void Update(ContatoModel contato);
    void Delete(ContatoModel contato);
}