using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> signalX = new List<double>();
            List<double> signalY = new List<double>();
            for (double i = 0.0; i < 2 * Math.PI * 10; i += 0.5)
            {
                signalX.Add(i);
                signalY.Add(Math.Sin(i));
            }

            for (int i = 0; i < signalX.Count; ++i)
            {
                Console.WriteLine(signalX[i]);
            }
            Console.WriteLine();
            for (int i = 0; i < signalY.Count; ++i)
            {
                Console.WriteLine(signalY[i]);
            }
            Console.WriteLine();

            DFT dft = new DFT();
            dft.Run(signalX, signalY);

            for (int i = 0; i < dft.Re.Count; ++i)
            {
                Console.WriteLine(dft.Amp[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < dft.Re.Count; ++i)
            {
                Console.WriteLine(dft.Freq[i]);
            }
            Console.ReadLine();
        }
    }
}
