using CadastroContatos.Models;
using CadastroContatos.ViewModel;

namespace CadastroContatos.Services.Interfaces;

public interface IContatosService
{
    List<ConsultaContatosViewModel> GetContatos(FiltroContatoViewModel filtro);
    ContatoModel GetContatoById(int id);
    void CreateContato(ContatoViewModel model);
    void UpdateContato(ContatoViewModel model);
    void DeleteContato(int id);
}