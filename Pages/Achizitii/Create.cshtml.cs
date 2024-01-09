using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Achizitii
{
    public class CreateModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public CreateModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MembruID"] = new SelectList(_context.Membru, "ID", "NumeComplet");
        ViewData["VaccinID"] = new SelectList(_context.Vaccin, "ID", "Nume");
            return Page();
        }

        [BindProperty]
        public Achizitie Achizitie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Achizitie == null || Achizitie == null)
            {
                return Page();
            }

            _context.Achizitie.Add(Achizitie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
