using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BeerListsWindow")]

namespace lab2
{
    internal class BeerList : DbContext
    {
        public virtual DbSet<Beer> Beers { set; get; }
        public List<Beer> DownloadBeers { set; get; }

        public BeerList()
        {
            
        }
        public BeerList(string country)
        {
            
        }
        public async Task<List<Beer>> GetList(string country)
        {
            var beers = this.Beers.SqlQuery("SELECT * FROM Beers WHERE Country ='" + country + "'").ToList<Beer>();
            if (beers.Count == 0)
            {
                var json = await this.GetDataFromApi(country);
                var beers_json = JsonConvert.DeserializeObject<List<Beer>>(json);

                foreach (var beer in beers_json)
                {
                    beer.Country = country;
                    this.Beers.Add(beer);
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
    }
}
