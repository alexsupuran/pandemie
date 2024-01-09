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

namespace pandemie.Pages.Tipuri
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
            return Page();
        }

        [BindProperty]
        public Tip Tip { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tip == null || Tip == null)
            {
                return Page();
            }

            _context.Tip.Add(Tip);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
