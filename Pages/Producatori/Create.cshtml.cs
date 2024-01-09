using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Producatori
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public CreateModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["VaccinID"] = new SelectList(_context.Set<Vaccin>(), "ID",
            "Nume");
            ViewData["TaraID"] = new SelectList(
            _context.Set<Tara>()
            .GroupBy(t => t.Name)
            .Select(g => g.First())
            .ToList(),
            "ID",
            "Name"
            );
            return Page();
        }

        [BindProperty]
        public Producator Producator { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Producator == null || Producator == null)
            {
                return Page();
            }

            _context.Producator.Add(Producator);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
