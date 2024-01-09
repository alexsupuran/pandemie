using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Fonduri
{
    public class DetailsModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public DetailsModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

      public Fond Fond { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fond == null)
            {
                return NotFound();
            }

            var fond = await _context.Fond.FirstOrDefaultAsync(m => m.ID == id);
            Fond = await _context.Fond
            .Include(p => p.Tara)
            .FirstOrDefaultAsync(m => m.ID == id);
            if (fond == null)
            {
                return NotFound();
            }
            else 
            {
                Fond = fond;
            }
            return Page();
        }
    }
}
