using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Concessionaria.Data;
using Concessionaria.Models;

namespace Concessionaria.Pages.Opcionais
{
    public class EditModel : PageModel
    {
        private readonly Concessionaria.Data.ConcessionariaDbContext _context;

        public EditModel(Concessionaria.Data.ConcessionariaDbContext context)
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

            var opcional =  await _context.Opcional.FirstOrDefaultAsync(m => m.OpcionalId == id);
            if (opcional == null)
            {
                return NotFound();
            }
            Opcional = opcional;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Opcional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpcionalExists(Opcional.OpcionalId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OpcionalExists(int id)
        {
          return (_context.Opcional?.Any(e => e.OpcionalId == id)).GetValueOrDefault();
        }
    }
}
