using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab4.Data;
using lab4.Models;

namespace lab4.Pages.Beers
{
    public class DeleteModel : PageModel
    {
        private readonly lab4.Data.lab4Context _context;

        public DeleteModel(lab4.Data.lab4Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Beer Beer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Beer == null)
            {
                return NotFound();
            }

            var beer = await _context.Beer.FirstOrDefaultAsync(m => m.ID == id);

            if (beer == null)
            {
                return NotFound();
            }
            else 
            {
                Beer = beer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Beer == null)
            {
                return NotFound();
            }
            var beer = await _context.Beer.FindAsync(id);

            if (beer != null)
            {
                Beer = beer;
                _context.Beer.Remove(Beer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
