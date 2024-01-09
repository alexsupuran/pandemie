using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pandemie.Data;
using pandemie.Models.ViewModels;
using pandemie.Models;

namespace pandemie.Pages.Tari
{
    public class IndexModel : PageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public IndexModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

        public IList<Tara> Tara { get; set; } = default!;
        public TaraIndexData TaraData { get; set; }
        public int TaraID { get; set; }
        public int ProducatorID { get; set; }
        public async Task OnGetAsync(int? id, int? producatorID)
        {
            TaraData = new TaraIndexData();
            TaraData.Tari = await _context.Tara
            .Include(i => i.Producatori)
            .ThenInclude(c => c.Vaccin)
            .OrderBy(i => i.Name)
            .ToListAsync();
            if (id != null)
            {
                TaraID = id.Value;
                Tara tara = TaraData.Tari
                .Where(i => i.ID == id.Value).Single();
                TaraData.Producatori = tara.Producatori;
            }
        }
    }
}
