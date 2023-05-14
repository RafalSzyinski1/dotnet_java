using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab4.Models;
using System.Diagnostics.Metrics;
using Newtonsoft.Json;
using NuGet.Packaging;

namespace lab4.Data
{
    public class lab4Context : DbContext
    {
        public lab4Context (DbContextOptions<lab4Context> options)
            : base(options)
        {
            List<string> country_list = new();
            country_list.AddRange(new string[] {
            "All",
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
            "malta"});
            foreach (string country in country_list)
            {
                var a = GetList(country).Result;

            }
        }

        public async Task<List<lab4.Models.Beer>> GetList(string country)
        {
            var beers = this.Beer.FromSqlRaw("SELECT * FROM Beer WHERE Country ='" + country + "'").ToList<lab4.Models.Beer>();
            if (beers.Count == 0)
            {
                var json = await this.GetDataFromApi(country);
                var beers_json = JsonConvert.DeserializeObject<List<lab4.Models.Beer>>(json);

                foreach (var beer in beers_json)
                {
                    beer.Country = country;
                    this.Beer.Add(beer);
                }
                this.SaveChanges();
                return beers_json;
            }
            return beers;
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

        public virtual DbSet<lab4.Models.Beer> Beer { get; set; } = default!;

        public virtual DbSet<lab4.Models.MyBeer>? MyBeer { get; set; }
    }
}
