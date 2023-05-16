﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab4.Data;
using Lab4.Models;

namespace Lab4.Pages.Beers
{
    public class IndexModel : PageModel
    {
        private readonly Lab4.Data.Lab4Context _context;

        public IndexModel(Lab4.Data.Lab4Context context)
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
