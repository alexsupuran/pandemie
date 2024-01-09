using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Producatori
{
    public class DetailsModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public DetailsModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

      public Producator Producator { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Producator == null)
            {
                return NotFound();
            }

            var producator = await _context.Producator.FirstOrDefaultAsync(m => m.ID == id);
            Producator = await _context.Producator
            .Include(p => p.Vaccin)
            .FirstOrDefaultAsync(m => m.ID == id);
            Producator = await _context.Producator
            .Include(p => p.Tara)
            .FirstOrDefaultAsync(m => m.ID == id);
            if (producator == null)
            {
                return NotFound();
            }
            else 
            {
                Producator = producator;
            }
            return Page();
        }
    }
}
