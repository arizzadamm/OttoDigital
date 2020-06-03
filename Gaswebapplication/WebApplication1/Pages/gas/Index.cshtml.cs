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
    public class IndexModel : PageModel
    {
        private readonly GasOnline.Data.GasOnlineContext _context;

        public IndexModel(GasOnline.Data.GasOnlineContext context)
        {
            _context = context;
        }

        public IList<Gas> Gas { get;set; }

        public async Task OnGetAsync()
        {
            Gas = await _context.Gas.ToListAsync();
        }
    }
}
