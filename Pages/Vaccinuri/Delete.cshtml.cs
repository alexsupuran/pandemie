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

namespace pandemie.Pages.Vaccinuri
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
      public Vaccin Vaccin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vaccin == null)
            {
                return NotFound();
            }

            var vaccin = await _context.Vaccin.FirstOrDefaultAsync(m => m.ID == id);

            if (vaccin == null)
            {
                return NotFound();
            }
            else 
            {
                Vaccin = vaccin;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Vaccin == null)
            {
                return NotFound();
            }
            var vaccin = await _context.Vaccin.FindAsync(id);

            if (vaccin != null)
            {
                Vaccin = vaccin;
                _context.Vaccin.Remove(Vaccin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
