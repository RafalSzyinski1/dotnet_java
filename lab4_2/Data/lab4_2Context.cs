using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab4_2.Models;
using Newtonsoft.Json;

namespace lab4_2.Data
{
    public class lab4_2Context : DbContext
    {
        public lab4_2Context (DbContextOptions<lab4_2Context> options)
            : base(options)
        {
            InitAllBeers();
        }

        public void InitAllBeers()
        {
            string[] countries = new string[]{
            "denmark",
            "sweden",
            "belgium",
            "spain",
            "portugal",
            "ireland",
            "luxembourg",
            "norway",
            "finland",
            "switzerland",
            "czech",
            "italy",
            "poland",
            "malta"};
            foreach (string country in countries)
            {
                var a = InitBeers(country).Result;
            }
        }

        public async Task<int> InitBeers(string country)
        {
            var beers = this.Beer.FromSqlRaw("SELECT TOP 1 * FROM Beer WHERE Country ='" + country + "'").ToList<lab4_2.Models.Beer>();
            if (beers.Count == 0)
            {
                var json = await this.GetDataFromApi(country);
                var beers_json = JsonConvert.DeserializeObject<List<lab4_2.Models.Beer>>(json);

                foreach (var beer in beers_json)
                {
                    beer.Country = country;
                    this.Beer.Add(beer);
                }
                this.SaveChanges();
                return 2;
            }
            return 1;
        }

        public async Task<string> GetDataFromApi(string country = "")
        {
            var url = "https://beers-list.p.rapidapi.com/beers";
            if (!string.IsNullOrEmpty(country)) { url = url + "/" + country; }
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                    {
                        { "X-RapidAPI-Key", "f0d8a16872mshbc2aac74c6e1568p12745fjsn6334a67c6b8d" },
                        { "X-RapidAPI-Host", "beers-list.p.rapidapi.com" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        public DbSet<lab4_2.Models.Beer> Beer { get; set; } = default!;

        public DbSet<lab4_2.Models.MyBeer>? MyBeer { get; set; }
    }
}
