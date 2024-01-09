using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Fonduri
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
        ViewData["TaraID"] = new SelectList(_context.Tara, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Fond Fond { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Fond == null || Fond == null)
            {
                return Page();
            }

            _context.Fond.Add(Fond);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
