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
        static void Main(string[] args)
        {
            BeerList a = new BeerList();
            foreach (var item in a.DownloadBeers)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
    }
}
