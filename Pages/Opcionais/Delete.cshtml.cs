using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Concessionaria.Data;
using Concessionaria.Models;

namespace Concessionaria.Pages.Opcionais
{
    public class DeleteModel : PageModel
    {
        private readonly Concessionaria.Data.ConcessionariaDbContext _context;

        public DeleteModel(Concessionaria.Data.ConcessionariaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Opcional Opcional { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Opcional == null)
            {
                return NotFound();
            }

            var opcional = await _context.Opcional.FirstOrDefaultAsync(m => m.OpcionalId == id);

            if (opcional == null)
            {
                return NotFound();
            }
            else 
            {
                Opcional = opcional;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Opcional == null)
            {
                return NotFound();
            }
            var opcional = await _context.Opcional.FindAsync(id);

            if (opcional != null)
            {
                Opcional = opcional;
                _context.Opcional.Remove(Opcional);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
