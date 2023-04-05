using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace lab2
{
    internal class BeerList
    {

        public async Task<List<Beer>> getList(string country = "")
        {
            var json = await getDataFromApi(country);
            return JsonConvert.DeserializeObject<List<Beer>>(json);
        }

        public async Task<string> getDataFromApi(string country = "")
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
