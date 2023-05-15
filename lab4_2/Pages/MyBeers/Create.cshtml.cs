using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab4_2.Data;
using lab4_2.Models;

namespace lab4_2.Pages.MyBeers
{
    public class CreateModel : PageModel
    {
        private readonly lab4_2.Data.lab4_2Context _context;

        public CreateModel(lab4_2.Data.lab4_2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MyBeer? MyBeer { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("./Add", new { title = MyBeer.Title, alchool = MyBeer.Alchool, country=MyBeer.Country });

        }
    }
}
