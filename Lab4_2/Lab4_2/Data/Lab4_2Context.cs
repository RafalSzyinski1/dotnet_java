using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab4_2.Models;

namespace Lab4_2.Data
{
    public class Lab4_2Context : DbContext
    {
        public Lab4_2Context (DbContextOptions<Lab4_2Context> options)
            : base(options)
        {
        }

        public DbSet<Lab4_2.Models.Beer> Beer { get; set; } = default!;
    }
}
