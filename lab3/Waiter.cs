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
        object CheckForkLock;
        object AssignForksLock;
        List<int> Forks;
        List<Philosopher> Philosophers;
        int SizeOfPhilosophers;
        public Waiter(int sizeOfPhilosophers)
        {
            CheckForkLock = new object();
            AssignForksLock = new object();

            Forks = new List<int>();
            Philosophers = new List<Philosopher>();
            SizeOfPhilosophers = sizeOfPhilosophers;

            for (int i = 0; i < sizeOfPhilosophers; i++)
            {
                Forks.Add(i);
                Philosophers.Add(new Philosopher(this, i));
                new Thread(Philosophers[i].Live).Start();
            }
        }

        public void RequireForks(Philosopher philosopher)
        {
            bool wait = true;
            int num = philosopher.GetNum();
            int left = num == 0 ? SizeOfPhilosophers - 1 : num - 1;
            int right = num == SizeOfPhilosophers - 1 ? 0 : num + 1;

            while (tryLockForks(left, right))
                Thread.Sleep(100);
        }

        public bool tryLockForks (int fork1, int fork2)
        {
            int isFork1 = -1, isFork2 = -1;
            lock(AssignForksLock)
            {
                for (int i = 0; i < Forks.Count; ++i)
                {
                    if (fork1 == Forks[i])
                        isFork1 = i;
                    if (fork2 == Forks[i])
                        isFork2 = i;
                }
                
                if (isFork1 != -1 &&  isFork2 != -1)
                {
                    Forks.RemoveAt(isFork1);
                    Forks.RemoveAt(isFork2);
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
                Forks.Add(left);
                Forks.Add(right);
            }
        }
    }
}
