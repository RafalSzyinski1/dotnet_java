using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab4_2.Data;
using lab4_2.Models;

namespace lab4_2.Pages.MyBeers
{
    public class IndexModel : PageModel
    {
        private readonly lab4_2.Data.lab4_2Context _context;

        public IndexModel(lab4_2.Data.lab4_2Context context)
        {
            _context = context;
        }

        public IList<MyBeer> MyBeer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MyBeer != null)
            {
                MyBeer = await _context.MyBeer.ToListAsync();
            }
        }
    }
}
