using CadastroContatos.Models;
using CadastroContatos.Services.Interfaces;
using CadastroContatos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CadastroContatos.Controllers;

public class ContatoController(IContatosService contatoService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult ContatosGrid(FiltroContatoViewModel filtro)
    {
        try
        {
            var contatos = contatoService.GetContatos(filtro);
            return PartialView("_PartialGridContatos", contatos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet]
    public IActionResult CreateContato()
    {
        return View("CreateContato");
    }
    
    [HttpPost]
    public IActionResult CreateContato(ContatoViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        try
        {
            contatoService.CreateContato(model);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(model);
        }
    }
    
    [HttpGet]
    public IActionResult UpdateContato(int id)
    {
        ContatoModel contato = contatoService.GetContatoById(id);

        ContatoViewModel model = new()
        {
            Nome = contato.Nome,
            TelefoneComercial = contato.TelefoneComercial,
            TelefonePessoal = contato.TelefonePessoal,
            DataInclusao = contato.DataInclusao,
            Empresa = contato.Empresa,
            Emails = contato.Emails.Select(s => s.Email).ToList()
        };
        
        return View("UpdateContato", model);
    }

    [HttpPost]
    public IActionResult UpdateContato(ContatoViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
    
        try
        {
            contatoService.UpdateContato(model);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(model);
        }
    }
    
    [HttpPost]
    public IActionResult DeleteContato(int id)
    {
        try
        {
            contatoService.DeleteContato(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}