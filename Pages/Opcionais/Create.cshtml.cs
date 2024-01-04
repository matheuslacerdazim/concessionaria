using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Concessionaria.Data;
using Concessionaria.Models;

namespace Concessionaria.Pages.Opcionais
{
    public class CreateModel : PageModel
    {
        private readonly Concessionaria.Data.ConcessionariaDbContext _context;

        public CreateModel(Concessionaria.Data.ConcessionariaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Opcional Opcional { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Opcional == null || Opcional == null)
            {
                return Page();
            }

            _context.Opcional.Add(Opcional);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
