using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbe przedmiontow: ");
            int n = int.Parse(Console.ReadLine());
            Knapsack k = new Knapsack(n, 1);
            Console.WriteLine(k);
            Console.WriteLine(k.run(30));
            Console.Read();
        }
    }
}
