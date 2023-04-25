using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab3_Marcin
{
    internal class Program
    {
        static object[] fork;
        static object mutex = new object();
        static bool mutex_free = true;

        static void Main(string[] args)
        {
            int num_of_phil;
            string input;
            Console.WriteLine("Podaj liczbę filozofów");
            input = Console.ReadLine();
            
            if(int.TryParse(input, out num_of_phil))
            {
                Console.WriteLine("Liczba filozofów wczytana poprawnie! ");
            }
            else
            {
                Console.WriteLine("Liczba wczytana niepoprawnie!");
                Console.ReadKey();
                return;
            }

            fork = new object[num_of_phil];
            for(int i=0; i < num_of_phil; i++)
            {
                fork[i] = new object();
            }

            Thread[] thread = new Thread[num_of_phil];
            Random rnd = new Random();

            for (int i=0; i < (num_of_phil-1); i++)
            {
                object[] temp_1 = new object[] { i, i+1, rnd.Next(100, 500) };
                thread[i] = new Thread(new ThreadStart(() => philosopher(temp_1)));
            }
            int id = num_of_phil - 1;
            object[] temp_2 = new object[] { id, 0, rnd.Next(100, 500) };
            thread[id] = new Thread(new ThreadStart(() => philosopher(temp_2)));

            foreach (Thread thr in thread)
                thr.Start();



            for(int i=0; i<thread.Count(); i++)
            {
                thread[i].Join();
            }
            Console.WriteLine("KONIEC");
            Console.ReadKey();
        }

        public static void think(int id, int delay_time)
        {
            Console.WriteLine("Filozof " +  id.ToString() + " myśli...");
            Thread.Sleep(delay_time);
        }

        public static void philosopher(object parameters)
        {
            object[] MyParams = (object[])parameters;
            int id = (int)MyParams[0];
            int left = (int)MyParams[0];
            int right = (int)MyParams[1];
            int delay_time = (int)MyParams[2];
            think(id,delay_time);
            bool hungry = true;

            while(hungry)
            {
                
                bool lockTaken = false;
                Monitor.TryEnter(mutex, ref lockTaken);
                if (lockTaken)
                {
                    try
                    {
                        lock (mutex)
                        {
                            lock (fork[left])
                            {
                                lock (fork[right])
                                {
                                    Console.WriteLine("Filozof " + id.ToString() + " je");
                                    Thread.Sleep (delay_time);
                                    hungry = false;
                                }
                            }
                            Console.WriteLine("Filozof " + id.ToString() + " jest najedzony! :)");
                        }
                    }
                    finally
                    {
                        Monitor.Exit(mutex);
                    }
                }
                else
                {
                    Console.WriteLine("Filozof " + id.ToString() + " jest głodny!");
                    Thread.Sleep(3*delay_time);
                }
            }
            

        }


    }
}
