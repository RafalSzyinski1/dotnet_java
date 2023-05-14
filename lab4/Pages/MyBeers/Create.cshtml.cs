using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab4.Data;
using lab4.Models;

namespace lab4.Pages.MyBeers
{
    public class CreateModel : PageModel
    {
        private readonly lab4.Data.lab4Context _context;

        public CreateModel(lab4.Data.lab4Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MyBeer MyBeer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MyBeer == null || MyBeer == null)
            {
                return Page();
            }

            _context.MyBeer.Add(MyBeer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
