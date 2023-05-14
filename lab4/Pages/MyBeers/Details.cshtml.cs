using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab4.Data;
using lab4.Models;

namespace lab4.Pages.MyBeers
{
    public class DetailsModel : PageModel
    {
        private readonly lab4.Data.lab4Context _context;

        public DetailsModel(lab4.Data.lab4Context context)
        {
            _context = context;
        }

      public MyBeer MyBeer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MyBeer == null)
            {
                return NotFound();
            }

            var mybeer = await _context.MyBeer.FirstOrDefaultAsync(m => m.ID == id);
            if (mybeer == null)
            {
                return NotFound();
            }
            else 
            {
                MyBeer = mybeer;
            }
            return Page();
        }
    }
}
