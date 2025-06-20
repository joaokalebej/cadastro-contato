using CadastroContatos.Data;
using CadastroContatos.Repositories;
using CadastroContatos.Repositories.Interfaces;
using CadastroContatos.Services;
using CadastroContatos.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NonFactors.Mvc.Grid;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvcGrid();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IContatosService, ContatosService>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();

builder.Services.AddDbContext<DBContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();