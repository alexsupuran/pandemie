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
    public class IndexModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public IndexModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

        public IList<Achizitie> Achizitie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Achizitie != null)
            {
                Achizitie = await _context.Achizitie
                .Include(a => a.Membru)
                .Include(a => a.Vaccin).ToListAsync();
            }
        }
    }
}
