using lab4_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Linq;

namespace lab4_2.Pages.MyBeers
{
    public class AddModel : PageModel
    {
        private readonly lab4_2.Data.lab4_2Context _context;

        public AddModel(lab4_2.Data.lab4_2Context context)
        {
            _context = context;
            
        }

        [BindProperty]
        public IList<Beer> Beers { get; set; } = default!;
        public void OnGet()
        {
            string title = Request.Query["title"];
            string alchool = Request.Query["alchool"];
            string country = Request.Query["country"];
            Beers = _context.Beer.FromSqlRaw("SELECT * FROM Beer WHERE (Country LIKE '" + country + "%') OR (Alchool LIKE '" + alchool + "%') OR (Title LIKE '" + title + "%')").ToList<Beer>();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid || _context.MyBeer == null || id == null)
            {
                return Page();
            }
            var b = await _context.Beer.FindAsync(id);
            if (b != null)
            {
                var mybeer = new MyBeer
                {
                    Title = b.Title,
                    Alchool = b.Alchool,
                    Description = b.Description,
                    Country = b.Country
                };
                _context.MyBeer.Add(mybeer);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToPage("./Index");
        }
    }
}
