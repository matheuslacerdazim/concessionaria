using Concessionaria.Models;
using Concessionaria.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Concessionaria.Pages;

[Authorize]
public class CreateModel : PageModel
{
    public SelectList MarcaOptionItems { get; set; }
    public SelectList OpcionalOptionItems { get; set; }

    private ICarService _service;
    public CreateModel(ICarService service)
    {
        _service = service;
    }

    public void OnGet()
    {
        MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
            nameof(Marca.MarcaId),
            nameof(Marca.Descricao));

        OpcionalOptionItems = new SelectList(_service.ObterTodosOpcionais(),
            nameof(Opcional.OpcionalId),
            nameof(Opcional.Descricao));

    }

    [BindProperty]
    public Carro Carro { get; set; }

    [BindProperty]
    public IList<int> OpcionalIds { get; set; }


    public IActionResult OnPost()
    {
        Carro.Opcionais = _service.ObterTodosOpcionais()
                                  .Where(item => OpcionalIds.Contains(item.OpcionalId))
                                  .ToList();

        if (!ModelState.IsValid)
        {
            return Page();
        }

        //inclusão
        _service.IncluirCarro(Carro);

        return RedirectToPage("/Index");
    }
}
