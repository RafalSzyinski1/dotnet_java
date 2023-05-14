﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab4.Data;
using lab4.Models;

namespace lab4.Pages
{
    public class IndexModel : PageModel
    {
        private readonly lab4.Data.lab4Context _context;

        public IndexModel(lab4.Data.lab4Context context)
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
