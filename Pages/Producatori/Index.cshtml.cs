using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Producatori
{
    public class IndexModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public IndexModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }
        public string ProducatorSort { get; set; }
        public string VaccinSort { get; set; }

        public string CurrentFilter { get; set; }
        public IList<Producator> Producator { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)

        {
            ProducatorSort = String.IsNullOrEmpty(sortOrder) ? "nume_desc" : "";
            VaccinSort = sortOrder == "vaccin" ? "vaccind_desc" : "vaccin";
            CurrentFilter = searchString;

            IQueryable<Producator> producatoriQuery = _context.Producator
            .Include(b => b.Vaccin)
            .Include(b => b.Tara);

            if (!String.IsNullOrEmpty(searchString))
            {
                producatoriQuery = producatoriQuery.Where(s => s.Vaccin.Nume.Contains(searchString)
                                                            || s.Tara.Name.Contains(searchString));
            }

            Producator = await producatoriQuery.ToListAsync();

            switch (sortOrder)
            {
                case "nume_desc":
                    Producator = Producator.OrderByDescending(s => s.Nume).ToList();
                    break;
                case "vaccin_desc":
                    Producator = Producator.OrderByDescending(s => s.Vaccin?.Nume).ToList();
                    break;
                case "vaccin":
                    Producator = Producator.OrderBy(s => s.Vaccin?.Nume).ToList();
                    break;
                default:
                    Producator = Producator.OrderBy(s => s.Nume).ToList();
                    break;
            }
        }
    }
}
