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
            Console.WriteLine("Podaj seed: ");
            int s = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj wielkosc plecaka: ");
            int v = int.Parse(Console.ReadLine());
            Knapsack k = new Knapsack(n, s);
            Console.WriteLine(k);
            Console.WriteLine(k.run(v));
            Console.Read();
        }
    }
}
