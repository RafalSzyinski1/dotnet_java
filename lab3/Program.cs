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
            List<double> signal = new List<double>();
            for (double i = 0.0; i < 2 * Math.PI * 10; i += 0.5)
            {
                signal.Add(Math.Sin(i));
            }

            using (StreamWriter writer = new StreamWriter("sig.csv"))
            {
                for (int i = 0; i < signal.Count; i++)
                {
                    writer.WriteLine($"{i}, {signal[i]}");
                }
            }
       

            DFT dft = new DFT();
            dft.Run(signal);
            dft.ToCSV("signal.csv");

            Console.ReadLine();
        }
    }
}
