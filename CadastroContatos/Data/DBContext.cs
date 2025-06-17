using CadastroContatos.Models;
using Microsoft.EntityFrameworkCore;
// ReSharper disable All

namespace CadastroContatos.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }
    
    public DbSet<ContatoModel> Contatos { get; set; }
}