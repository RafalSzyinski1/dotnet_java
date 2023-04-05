using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            BeerList a = new BeerList();
            var b = a.getList().Result;
            foreach (var item in b)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}
