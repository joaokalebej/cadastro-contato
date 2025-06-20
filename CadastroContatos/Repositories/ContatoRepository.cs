using CadastroContatos.Data;
using CadastroContatos.Models;
using CadastroContatos.Repositories.Interfaces;
using CadastroContatos.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CadastroContatos.Repositories;

public class ContatoRepository(DBContext dbContext) : IContatoRepository
{
    public List<ContatoModel> GetAll()
    {
        return dbContext.Contatos
            .AsNoTracking()
            .ToList();
    }

    public ContatoModel GetById(int id)
    {
        return dbContext.Contatos
            .Include(i => i.Emails)
            .AsNoTracking()
            .First(f => f.Id == id);
    }

    public void Add(ContatoModel contato)
    {
        if (contato is null)
            throw new Exception("Contato não foi enviado com sucesso");

        dbContext.Contatos.Add(contato);
        dbContext.SaveChanges();
    }

    public void Update(ContatoModel contato)
    {
        DeleteEmail(contato);
        
        if (contato is null)
            throw new Exception("Contato não foi enviado com sucesso");

        dbContext.Contatos.Update(contato);
        dbContext.SaveChanges();
    }

    public void Delete(ContatoModel contato)
    {
        dbContext.Contatos.Remove(contato);
        dbContext.SaveChanges();
    }
    
    public void DeleteEmail(ContatoModel contato)
    {
        dbContext.ContatoEmail.Where(w => w.ContatoId == contato.Id)
            .ExecuteDelete();
    }

    public IQueryable<ConsultaContatosViewModel> GetConsulta()
    {
        IQueryable<ConsultaContatosViewModel> query = dbContext.ConsultaContato.AsQueryable()
            .OrderByDescending(o => o.DataInclusao);
        return query;
    }
}