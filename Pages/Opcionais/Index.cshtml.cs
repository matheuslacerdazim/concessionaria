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
    public class IndexModel : PageModel
    {
        private readonly Concessionaria.Data.ConcessionariaDbContext _context;

        public IndexModel(Concessionaria.Data.ConcessionariaDbContext context)
        {
            _context = context;
        }

        public IList<Opcional> Opcional { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Opcional != null)
            {
                Opcional = await _context.Opcional.ToListAsync();
            }
        }
    }
}
