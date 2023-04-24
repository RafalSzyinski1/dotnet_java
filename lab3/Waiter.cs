using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab3
{
    internal class Waiter
    {
        object AssignForksLock;
        bool[] Forks;
        Philosopher[] Philosophers;
        Thread[] Threads;
        int SizeOfPhilosophers;
        public Waiter(int sizeOfPhilosophers)
        {
            AssignForksLock = new object();

            Forks = new bool[sizeOfPhilosophers];
            Philosophers = new Philosopher[sizeOfPhilosophers];
            SizeOfPhilosophers = sizeOfPhilosophers;
            Threads = new Thread[sizeOfPhilosophers];

            for (int i = 0; i < sizeOfPhilosophers; i++)
            {
                Forks[i] = true;
                Philosophers[i] = new Philosopher(this, i);
                Threads[i] = new Thread(Philosophers[i].Live);
                Threads[i].Start();
            }
        }

        public void RequireForks(Philosopher philosopher)
        {
            int num = philosopher.GetNum();
            int left = num == 0 ? SizeOfPhilosophers - 1 : num - 1;
            int right = num == SizeOfPhilosophers - 1 ? 0 : num + 1;

            while (TryLockForks(left, right))
                Thread.Sleep(100);
        }

        public bool TryLockForks (int fork1, int fork2)
        {
            lock(AssignForksLock)
            {   
                if (Forks[fork1] && Forks[fork2])
                {
                    Forks[fork1] = false;
                    Forks[fork2] = false;
                    return true; // TEST
                }
            }
            return false;
        }
        public void ReleaseForks(Philosopher philosopher)
        {
            lock (AssignForksLock)
            {
                int num = philosopher.GetNum();
                int left = num == 0 ? SizeOfPhilosophers - 1 : num - 1;
                int right = num == SizeOfPhilosophers - 1 ? 0 : num + 1;
                Forks[left] = true;
                Forks[right] = true;
            }
        }

        public void Join()
        {
            foreach (Thread T in Threads)
            {
                T.Join();
            }
        }
    }
}
