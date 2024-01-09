using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Producatori
{
    [Authorize(Roles = "Admin")]

    public class DeleteModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public DeleteModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Producator == null)
            {
                return NotFound();
            }
            var producator = await _context.Producator.FindAsync(id);

            if (producator != null)
            {
                Producator = producator;
                _context.Producator.Remove(Producator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
