using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using pandemie.Data;
using pandemie.Models;

namespace pandemie.Pages.Vaccinuri
{
    [Authorize(Roles = "Admin")]

    public class EditModel : VaccinTipuriPageModel
    {
        private readonly pandemie.Data.pandemieContext _context;

        public EditModel(pandemie.Data.pandemieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vaccin Vaccin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

   
            Vaccin = await _context.Vaccin
            .Include(b => b.VaccinTipuri).ThenInclude(b => b.Tip)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (Vaccin == null)
            {
                return NotFound();
            }
            PopulateAssignedTipData(_context, Vaccin);
            return Page();
        }
        


        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedTipuri)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var vaccinToUpdate = await _context.Vaccin
            .Include(i => i.VaccinTipuri)
            .ThenInclude(i => i.Tip)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (vaccinToUpdate == null)
            {
                return NotFound();
            }
           
            if (await TryUpdateModelAsync<Vaccin>(
            vaccinToUpdate,
            "Vaccin",
              i => i.Nume,              
              i => i.Pret_achizitie,    
              i => i.Data_aprobare,     
              i => i.Producatori,               
              i => i.Informatii))
            {
                UpdateVaccinTipuri(_context, selectedTipuri, vaccinToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
           
            UpdateVaccinTipuri(_context, selectedTipuri, vaccinToUpdate);
            PopulateAssignedTipData(_context, vaccinToUpdate);
            return Page();
        }
    }
}
