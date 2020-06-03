using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GasOnline.Data;
using Gas_Online.Models;

namespace GasOnline.Pages.gas
{
    public class EditModel : PageModel
    {
        private readonly GasOnline.Data.GasOnlineContext _context;

        public EditModel(GasOnline.Data.GasOnlineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Gas Gas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gas = await _context.Gas.FirstOrDefaultAsync(m => m.ID == id);

            if (Gas == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Gas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GasExists(Gas.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GasExists(int id)
        {
            return _context.Gas.Any(e => e.ID == id);
        }
    }
}
