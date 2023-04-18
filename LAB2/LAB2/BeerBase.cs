using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    internal class BeerBase : DbContext
    {
        public BeerBase()
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Beer> Beers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(@"Data Source=Univ.db");


    }
}

