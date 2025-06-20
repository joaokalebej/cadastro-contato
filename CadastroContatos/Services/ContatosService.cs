using CadastroContatos.Data;
using CadastroContatos.Models;
using CadastroContatos.Repositories.Interfaces;
using CadastroContatos.Services.Interfaces;
using CadastroContatos.ViewModel;

namespace CadastroContatos.Services;

public class ContatosService(IContatoRepository contatoRepository) : IContatosService
{
    public List<ConsultaContatosViewModel> GetContatos(FiltroContatoViewModel filtro)
    {
        List<ConsultaContatosViewModel> dados;
        try
        {
            IQueryable<ConsultaContatosViewModel> query = contatoRepository.GetConsulta();

            if (!string.IsNullOrEmpty(filtro.Nome))
                query = query.Where(w => w.Nome.Contains(filtro.Nome));
            
            if (!string.IsNullOrEmpty(filtro.Empresa))
                query = query.Where(w => w.Empresa.Contains(filtro.Empresa));

            if (!string.IsNullOrEmpty(filtro.TelefoneComercial))
                query = query.Where(w => w.TelefoneComercial.Contains(filtro.TelefoneComercial));
            
            if (!string.IsNullOrEmpty(filtro.TelefonePessoal))
                query = query.Where(w => w.TelefonePessoal.Contains(filtro.TelefonePessoal));
            
            if (!string.IsNullOrEmpty(filtro.Email))
                query = query.Where(w => w.Emails.Contains(filtro.Email));

            dados = query.ToList();
            
            return dados;
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

    public void CreateContato(ContatoViewModel model)
    {
        try
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "O modelo de contato não pode ser nulo.");
            
            ContatoModel contato = new()
            {
                DataInclusao = DateTime.UtcNow,
                Empresa = model.Empresa,
                Nome = model.Nome,
                TelefonePessoal = model.TelefonePessoal,
                TelefoneComercial = model.TelefoneComercial,
                Emails = model.Emails.Select(s => new ContatoEmailModel
                {
                   Email = s,
                }).ToList()
            };
            contatoRepository.Add(contato);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao adicionar contato!", ex);
        }
    }
    
    public void UpdateContato(ContatoViewModel model)
    {
        try
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "O modelo de contato não pode ser nulo.");
            
            ContatoModel contato = new()
            {
                Id = model.Id,
                DataInclusao = model.DataInclusao,
                Nome = model.Nome,
                Empresa =  model.Empresa,
                TelefonePessoal = model.TelefonePessoal,
                TelefoneComercial = model.TelefoneComercial,
                Emails = model.Emails.Select(s => new ContatoEmailModel
                {
                    Email = s,
                }).ToList()
            };
            contatoRepository.Update(contato);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao atualizar contato!", ex);
        }
    }

    public void DeleteContato(int id)
    {
        ContatoModel contato = contatoRepository.GetById(id);

        if (contato == null)
            throw new Exception("Contato não encontrado.");

        contatoRepository.Delete(contato);
    }

}