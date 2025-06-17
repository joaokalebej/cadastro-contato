using CadastroContatos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CadastroContatos.Controllers;

public class ContatoController(IContatosService contatoService) : Controller
{
    public IActionResult Index()
    {
        try
        {
            var contatos = contatoService.GetAllContatos();
            return View(contatos);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "An error occurred while retrieving contacts.");
            return BadRequest(ex);
        }
    }

    public PartialViewResult ContatosGrid()
    {
        return PartialView("_PartialGridContatos", contatoService.GetAllContatos());
    }
}