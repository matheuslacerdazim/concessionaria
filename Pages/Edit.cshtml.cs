using Concessionaria.Models;
using Concessionaria.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Concessionaria.Pages;

[Authorize]
public class EditModel : PageModel
{
    public SelectList MarcaOptionItems { get; set; }
    public SelectList OpcionalOptionItems { get; set; }

    private ICarService _service;
    public EditModel(ICarService service)
    {
        _service = service;
    }

    [BindProperty]
    public Carro Carro { get; set; }

    [BindProperty]
    public IList<int> OpcionalIds { get; set; }

    public IActionResult OnGet(int id)
    {
        //var service = new HamburguerService(); Acoplamento eliminado pela injeção
        Carro = _service.ObterUmCarro(id);

        OpcionalIds = Carro.Opcionais.Select(item => item.OpcionalId).ToList();

        MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
                                                   nameof(Marca.MarcaId),
                                                   nameof(Marca.Descricao));

        OpcionalOptionItems = new SelectList(_service.ObterTodosOpcionais(),
                                                      nameof(Opcional.OpcionalId),
                                                      nameof(Opcional.Descricao));

        if (Carro == null)
        {
            return NotFound();
        }

        return Page();

    }

    public IActionResult OnPost()
    {
        Carro.Opcionais = _service.ObterTodosOpcionais()
                                  .Where(item => OpcionalIds.Contains(item.OpcionalId))
                                  .ToList();

        if (!ModelState.IsValid)
        {
            return Page();
        }

        //alteração
        _service.Alterar(Carro);

        return RedirectToPage("/Index");
    }

    public IActionResult OnPostExclusao()
    {
        _service.Excluir(Carro.Id);
        return RedirectToPage("/Index");
    }
}


