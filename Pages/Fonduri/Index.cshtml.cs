using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Fonduri
{
    public class IndexModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public IndexModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

        public IList<Fond> Fond { get; set; } = default!;
        public string OrdinSort { get; set; }
        public string TaraSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            OrdinSort = String.IsNullOrEmpty(sortOrder) ? "ordin_desc" : "";
            TaraSort = sortOrder == "tara_asc" ? "tara_desc" : "tara_asc";
            CurrentFilter = searchString;

            var fonduriQuery = _context.Fond
                .Include(f => f.Tara)
                .AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                fonduriQuery = fonduriQuery.Where(f =>
                    f.Ordin.Contains(searchString) ||
                    f.Tara.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "ordin_desc":
                    fonduriQuery = fonduriQuery.OrderByDescending(f => f.Ordin);
                    break;
                case "tara_asc":
                    fonduriQuery = fonduriQuery.OrderBy(f => f.Tara.Name);
                    break;
                case "tara_desc":
                    fonduriQuery = fonduriQuery.OrderByDescending(f => f.Tara.Name);
                    break;
                default:
                    fonduriQuery = fonduriQuery.OrderBy(f => f.Ordin);
                    break;
            }

            Fond = await fonduriQuery.ToListAsync();
        }
    }
}
