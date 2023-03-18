using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Knapsack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj ilość przedmiotów i seeda:");
            int number = int.Parse(Console.ReadLine());
            int seed = int.Parse(Console.ReadLine());

            Knapsack knapsack = new Knapsack(number, seed);
            Console.WriteLine(knapsack);
            Console.WriteLine("\n");

            Console.WriteLine("Podaj maksymalną wagę plecaka:");
            int weight = int.Parse(Console.ReadLine());
            Backpack backpack = new Backpack(weight);
            knapsack.steal(backpack);
            Console.WriteLine(backpack);
            Console.ReadKey();
        }
    }
}
