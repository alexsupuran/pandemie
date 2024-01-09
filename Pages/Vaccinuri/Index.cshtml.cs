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
    public class IndexModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public IndexModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

        public IList<Vaccin> Vaccin { get;set; } = default!;
        public VaccinData VaccinD { get; set; }
        public int VaccinID { get; set; }
        public int TipID { get; set; }
        public async Task OnGetAsync(int? id, int? tipID)
        {
            VaccinD = new VaccinData();

            VaccinD.Vaccinuri = await _context.Vaccin
            .Include(b => b.VaccinTipuri)
            .ThenInclude(b => b.Tip)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                VaccinID = id.Value;
                Vaccin vaccin = VaccinD.Vaccinuri
                .Where(i => i.ID == id.Value).Single();
                VaccinD.Tipuri = vaccin.VaccinTipuri.Select(s => s.Tip);
            }
        }
    }
}
