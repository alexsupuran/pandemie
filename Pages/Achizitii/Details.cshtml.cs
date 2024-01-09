using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Achizitii
{
    public class DetailsModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public DetailsModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

      public Achizitie Achizitie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Achizitie == null)
            {
                return NotFound();
            }

            var achizitie = await _context.Achizitie.FirstOrDefaultAsync(m => m.ID == id);
            Achizitie = await _context.Achizitie
            .Include(p => p.Vaccin)
            .FirstOrDefaultAsync(m => m.ID == id);
            Achizitie = await _context.Achizitie
            .Include(p => p.Membru)
            .FirstOrDefaultAsync(m => m.ID == id);
            if (achizitie == null)
            {
                return NotFound();
            }
            else 
            {
                Achizitie = achizitie;
            }
            return Page();
        }
    }
}
