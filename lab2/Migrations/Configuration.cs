namespace lab2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<lab2.BeerList>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "lab2.BeerList";
        }

        protected override void Seed(lab2.BeerList context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
