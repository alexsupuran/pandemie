using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Vaccinuri
{
    public class DetailsModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public DetailsModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

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
    }
}
