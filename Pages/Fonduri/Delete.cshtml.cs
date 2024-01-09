using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Fonduri
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
      public Fond Fond { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fond == null)
            {
                return NotFound();
            }

            var fond = await _context.Fond.FirstOrDefaultAsync(m => m.ID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Fond == null)
            {
                return NotFound();
            }
            var fond = await _context.Fond.FindAsync(id);
            Fond = await _context.Fond
            .Include(p => p.Tara)
            .FirstOrDefaultAsync(m => m.ID == id);

            if (fond != null)
            {
                Fond = fond;
                _context.Fond.Remove(Fond);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
