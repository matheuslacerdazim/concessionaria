using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Concessionaria.Data;
using Concessionaria.Models;

namespace Concessionaria.Pages.Marcas
{
    public class DetailsModel : PageModel
    {
        private readonly Concessionaria.Data.ConcessionariaDbContext _context;

        public DetailsModel(Concessionaria.Data.ConcessionariaDbContext context)
        {
            _context = context;
        }

      public Marca Marca { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Marca == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca.FirstOrDefaultAsync(m => m.MarcaId == id);
            if (marca == null)
            {
                return NotFound();
            }
            else 
            {
                Marca = marca;
            }
            return Page();
        }
    }
}
