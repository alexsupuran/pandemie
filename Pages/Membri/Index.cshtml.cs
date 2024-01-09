using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Membri
{
    public class IndexModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public IndexModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

        public IList<Membru> Membru { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Membru != null)
            {
                Membru = await _context.Membru.ToListAsync();
            }
        }
    }
}
