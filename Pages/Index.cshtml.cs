using Concessionaria.Models;
using Concessionaria.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Concessionaria.Pages;

public class IndexModel : PageModel
{
    private ICarService _service;

    public IndexModel(ICarService service)
    {
        _service = service;
    }

    public IList<Carro> ListaCarros { get; set; }

    public void OnGet()
    {
        ListaCarros = _service.ObterTodosOsCarros();
    }
}
