using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab4_2.Data;
using Lab4_2.Models;

namespace Lab4_2.Pages.Beers
{
    public class IndexModel : PageModel
    {
        private readonly Lab4_2.Data.Lab4_2Context _context;

        public IndexModel(Lab4_2.Data.Lab4_2Context context)
        {
            _context = context;
        }

        public IList<Beer> Beer { get;set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Beer != null)
            {
                Beer = await _context.Beer.ToListAsync();
            }
        }
    }
}
