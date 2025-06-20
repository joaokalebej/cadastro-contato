using CadastroContatos.Models;
using CadastroContatos.ViewModel;
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
    public DbSet<ContatoEmailModel> ContatoEmail { get; set; }

    public DbSet<ConsultaContatosViewModel> ConsultaContato { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConsultaContatosViewModel>().HasNoKey().ToView("v_consultacontatos");
    }
}