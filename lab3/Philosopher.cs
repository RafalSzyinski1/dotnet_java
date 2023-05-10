using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab3
{
    internal class Philosopher
    {
        int mThinkDelay;
        int mEatDelay;
        Waiter mWaiter;
        readonly int mNumOfPhilosopher;

        public Philosopher(Waiter waiter, int numOfPhilosopher)
        {
            Random rng = new Random(numOfPhilosopher);
            mThinkDelay = rng.Next() % 1000 + 500;
            mEatDelay = rng.Next() % 1000 + 500;
            mWaiter = waiter;
            mNumOfPhilosopher = numOfPhilosopher;
        }

        public void Think()
        {
            Console.WriteLine($"Philosopher {mNumOfPhilosopher} is thinking");
            Thread.Sleep(mThinkDelay);
        }

        public void Eat()
        {
            Console.WriteLine($"Philosopher {mNumOfPhilosopher} is hungry");
            mWaiter.RequireForks(this);
            Console.WriteLine($"Philosopher {mNumOfPhilosopher} is eatting");
            Thread.Sleep(mEatDelay);
            mWaiter.ReleaseForks(this);
        }

        public int GetNum()
        {
            return mNumOfPhilosopher;
        }

        public void Live()
        {
            Think();
            Eat();
        }
    }
}
