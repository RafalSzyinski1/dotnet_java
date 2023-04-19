using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class DFT
    {
        public List<double> Phase { set; get; }
        public List<double> Amp { set; get; }
        public List<double> Freq { set; get; }
        public List<double> Re { set; get; }
        public List<double> Im { set; get; }
        public double Phi { set; get; }

        public DFT() { 
            Phase = new List<double>(); 
            Amp = new List<double>(); 
            Freq = new List<double>(); 
            Re = new List<double>(); 
            Im = new List<double>();
            Phi = 0; 
        }

        public void Run(List<double> signal)
        {
            Phase.Clear();
            Amp.Clear();
            Freq.Clear();
            Re.Clear();
            Im.Clear();
            Phi = 0;

            int N = signal.Count;
            double re = 0;
            double im = 0;
            
            for (int i = 0; i <  N; i++)
            {
                for (int j = 0; j < N; ++j)
                {
                    double phi = 2 * (Math.PI * i * j) / N;
                    re += signal[j] * Math.Cos(phi);
                    im -= signal[j] * Math.Cos(phi);
                }

                re /= N;
                im /= N;

                Re.Add(re);
                Im.Add(im);
                Freq.Add(i);
                Amp.Add(Math.Sqrt(re * re + im * im));
                Phase.Add(Math.Atan2(im, re));
            }
        }

        public void ToCSV()
        {

        }

    }
}
