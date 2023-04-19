using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Waiter waiter = new Waiter(30);
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
