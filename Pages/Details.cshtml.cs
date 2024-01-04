using Concessionaria.Models;
using Concessionaria.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Concessionaria.Pages;

public class DetailsModel : PageModel
{

    private ICarService _service;

    public string DescricaoMarca {  get; set; }

    public DetailsModel(ICarService service)
    {
        _service = service;
    }

    public Carro Carro { get; set; }

    public IActionResult OnGet(int id)
    {
        Carro = _service.ObterUmCarro(id);
        if (Carro.MarcaId is not null) {
            DescricaoMarca = _service.ObterMarca(Carro.MarcaId.Value).Descricao;
        }
        
        if (Carro == null)
        {
            return NotFound();
        }

        return Page();
    }
}
