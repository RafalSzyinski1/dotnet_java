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
    public class DeleteModel : PageModel
    {
        private readonly lab4_2.Data.lab4_2Context _context;

        public DeleteModel(lab4_2.Data.lab4_2Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MyBeer == null)
            {
                return NotFound();
            }
            var mybeer = await _context.MyBeer.FindAsync(id);

            if (mybeer != null)
            {
                MyBeer = mybeer;
                _context.MyBeer.Remove(MyBeer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
