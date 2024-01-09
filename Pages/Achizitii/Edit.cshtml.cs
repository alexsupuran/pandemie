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

namespace pandemie.Pages.Achizitii
{
    public class EditModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public EditModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Achizitie Achizitie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Achizitie == null)
            {
                return NotFound();
            }

            var achizitie =  await _context.Achizitie.FirstOrDefaultAsync(m => m.ID == id);
            if (achizitie == null)
            {
                return NotFound();
            }
            Achizitie = achizitie;
           ViewData["MembruID"] = new SelectList(_context.Membru, "ID", "NumeComplet");
           ViewData["VaccinID"] = new SelectList(_context.Vaccin, "ID", "Nume");
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

            _context.Attach(Achizitie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchizitieExists(Achizitie.ID))
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

        private bool AchizitieExists(int id)
        {
          return (_context.Achizitie?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
