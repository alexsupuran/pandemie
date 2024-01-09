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

namespace pandemie.Pages.Vaccinuri
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : VaccinTipuriPageModel    
    {
        private readonly pandemie.Data.pandemieContext _context;

        public CreateModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var vaccin = new Vaccin();
            vaccin.VaccinTipuri = new List<VaccinTip>();
            PopulateAssignedTipData(_context, vaccin);
            return Page();
        }

        [BindProperty]
        public Vaccin Vaccin { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedTipuri)
        {
            var newVaccin = new Vaccin();
            if (selectedTipuri != null)
            {
                newVaccin.VaccinTipuri = new List<VaccinTip>();
                foreach (var cat in selectedTipuri)
                {
                    var catToAdd = new VaccinTip
                    {
                        TipID = int.Parse(cat)
                    };
                    newVaccin.VaccinTipuri.Add(catToAdd);
                }
            }
            Vaccin.VaccinTipuri = newVaccin.VaccinTipuri;
            _context.Vaccin.Add(Vaccin);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
