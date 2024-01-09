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

namespace pandemie.Pages.Tari
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
      public Tara Tara { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tara == null)
            {
                return NotFound();
            }

            var tara = await _context.Tara.FirstOrDefaultAsync(m => m.ID == id);

            if (tara == null)
            {
                return NotFound();
            }
            else 
            {
                Tara = tara;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tara == null)
            {
                return NotFound();
            }
            var tara = await _context.Tara.FindAsync(id);

            if (tara != null)
            {
                Tara = tara;
                _context.Tara.Remove(Tara);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
