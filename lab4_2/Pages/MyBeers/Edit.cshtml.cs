using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab4_2.Data;
using lab4_2.Models;

namespace lab4_2.Pages.MyBeers
{
    public class EditModel : PageModel
    {
        private readonly lab4_2.Data.lab4_2Context _context;

        public EditModel(lab4_2.Data.lab4_2Context context)
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

            var mybeer =  await _context.MyBeer.FirstOrDefaultAsync(m => m.ID == id);
            if (mybeer == null)
            {
                return NotFound();
            }
            MyBeer = mybeer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MyBeer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyBeerExists(MyBeer.ID))
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

        private bool MyBeerExists(int id)
        {
          return (_context.MyBeer?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
