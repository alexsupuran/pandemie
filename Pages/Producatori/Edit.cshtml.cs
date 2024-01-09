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

    public class EditModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public EditModel(pandemie.Data.pandemieContext context)
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

            var producator =  await _context.Producator.FirstOrDefaultAsync(m => m.ID == id);
            if (producator == null)
            {
                return NotFound();
            }
            Producator = producator;
            ViewData["VaccinID"] = new SelectList(_context.Set<Vaccin>().Distinct(), "ID",
            "Nume");
            ViewData["TaraID"] = new SelectList(
             _context.Set<Tara>()
            .GroupBy(t => t.Name)
            .Select(g => g.First())
        .   ToList(),
            "ID",
            "Name"
);
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

            _context.Attach(Producator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducatorExists(Producator.ID))
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

        private bool ProducatorExists(int id)
        {
          return (_context.Producator?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
