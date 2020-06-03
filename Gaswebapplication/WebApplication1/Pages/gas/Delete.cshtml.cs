using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GasOnline.Data;
using Gas_Online.Models;

namespace GasOnline.Pages.gas
{
    public class DeleteModel : PageModel
    {
        private readonly GasOnline.Data.GasOnlineContext _context;

        public DeleteModel(GasOnline.Data.GasOnlineContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Gas = await _context.Gas.FindAsync(id);

            if (Gas != null)
            {
                _context.Gas.Remove(Gas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
