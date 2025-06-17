using CadastroContatos.Data;
using CadastroContatos.Models;
using CadastroContatos.Repositories.Interfaces;
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
        if (contato is null)
            throw new Exception("Contato não foi enviado com sucesso");

        dbContext.Contatos.Update(contato);
        dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        ContatoModel contato = GetById(id);

        if (contato is null)
            throw new Exception("Contato não encontrado");
        
        dbContext.Contatos.Remove(contato);
        dbContext.SaveChanges();
    }
}