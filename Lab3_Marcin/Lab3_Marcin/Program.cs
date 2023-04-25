﻿using System;
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

            object[] fork = new object[num_of_phil];
            object mutex = new object();
            Thread[] thread = new Thread[num_of_phil];
            Random rnd = new Random();

            for (int i=0; i < (num_of_phil-1); i++)
            {
                object[] temp_1 = new object[] { i, fork[i], fork[i + 1], mutex, rnd.Next(200, 1000) };
                thread[i] = new Thread(new ThreadStart(() => philosopher(temp_1)));
                thread[i].Start();
            }
            int id = num_of_phil - 1;
            object[] temp_2 = new object[] { id, fork[id], fork[0], mutex, rnd.Next(200, 1000) };
            thread[id] = new Thread(new ThreadStart(() => philosopher(temp_2)));
            thread[id].Start();



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
            object left = MyParams[1];
            object right = MyParams[2];
            object mutex = MyParams[3];
            int delay_time = (int)MyParams[4];
            think(id,delay_time);
            bool hungry = true;

            while(hungry)
            {
                Console.WriteLine("Filozof " + id.ToString() + " jest głodny!");
                Thread.Sleep(delay_time);
                lock (mutex)
                {
                    lock(left)
                    {
                        lock (right)
                        {
                            Console.WriteLine("Filozof " + id.ToString() + " je");
                            Thread.Sleep (delay_time);
                            hungry = false;
                        }
                    }                    
                }
                Console.WriteLine("Filozof " + id.ToString() + " jest najedzony! :)");

            }
            

        }

        /*
        void MyThreadFunction(object parameters)
        {
            object[] myParams = (object[])parameters;
            int param1 = (int)myParams[0];
            string param2 = (string)myParams[1];
            bool param3 = (bool)myParams[2];
            // Funkcja, którą chcemy uruchomić w nowym wątku
        }

        // ...

        object[] myParams = new object[] { 42, "test", true };
        Thread myThread = new Thread(new ThreadStart(() => MyThreadFunction(myParams)));
        myThread.Start();
        */


    }
}
