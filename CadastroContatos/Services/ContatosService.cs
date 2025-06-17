using CadastroContatos.Models;
using CadastroContatos.Repositories.Interfaces;
using CadastroContatos.Services.Interfaces;

namespace CadastroContatos.Services;

public class ContatosService(IContatoRepository contatoRepository) : IContatosService
{
    public List<ContatoModel> GetAllContatos()
    {
        try
        {
            return contatoRepository.GetAll();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro!", ex);
        }
    }

    public ContatoModel GetContatoById(int id)
    {
        try
        {
            return contatoRepository.GetById(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro!", ex);
        }
    }
}