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

        public IList<lab4_2.Models.MyBeer> MyBeer { get;set; } = default!;

        public string TitleSort { get; set; }
        public string CountrySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            CountrySort = sortOrder == "Country" ? "country_desc" : "Country";

            IQueryable < lab4_2.Models.MyBeer > query = from s in _context.MyBeer select s;

            switch (sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(s => s.Title);
                    break;
                case "Country":
                    query = query.OrderBy(s => s.Country);
                    break;
                case "country_desc":
                    query = query.OrderByDescending(s => s.Country);
                    break;
                default:
                    query = query.OrderBy(s => s.Title);
                    break;
            }

                MyBeer = await query.AsNoTracking().ToListAsync();   
            
        }
    }
}
