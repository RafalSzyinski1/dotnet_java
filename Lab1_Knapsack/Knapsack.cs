﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Test_1"), InternalsVisibleTo("Lab1_desktop")]



namespace Lab1_Knapsack
{
    
    internal class Knapsack
    {
        private List<Item> items;

        public Knapsack(int number, int seed)
        {
            this.items = new List<Item>();
            Random random = new Random(seed);
            for(int i = 0; i < number; i++)
            {
                this.items.Add(new Item(random.Next(1, 10), random.Next(1, 10),this.items.Count));
            }
            this.KnapsackSort();
        }

        public void AddRandom(int number, int seed)
        {
            Random random = new Random(seed);
            for (int i = 0; i < number; i++)
            {
                this.items.Add(new Item(random.Next(1, 10), random.Next(1, 10), this.items.Count));
            }
            this.KnapsackSort();
        }

        public void AddItem(int weight, int value)
        {
            this.items.Add(new Item(weight,value, this.items.Count));
            this.KnapsackSort();
        }

        public override string ToString()
        {
            string str = "";
            foreach(Item item in this.items)
            {
                str += item.ToString() + Environment.NewLine;
            }
            return str;
        }

        public void KnapsackSort()
        {
            for(int i=0; i<this.items.Count; i++)
            {
                for(int j=1;  j<this.items.Count; j++)
                {
                    if (this.items[j - 1].GetRatio() < this.items[j].GetRatio())
                    {
                        int wj_1 = items[j - 1].GetWeight();
                        int vj_1 = items[j - 1].GetValue();
                        int wj = items[j].GetWeight();
                        int vj = items[j].GetValue();

                        this.items[j].SetValue(vj_1);
                        this.items[j].SetWeight(wj_1);
                        this.items[j - 1].SetValue(vj);
                        this.items[j - 1].SetWeight(wj);
                    }
                }
            }
        }

        public void steal(Backpack backpack)
        {
            foreach(Item item in this.items)
            {
                int weight = item.GetWeight();
                if(weight + backpack.act_weight <= backpack.max_weight)
                {
                    backpack.act_weight += weight;
                    backpack.items.Add(item);
                }
                if (backpack.act_weight == backpack.max_weight) break;
            }
        }

        public int GetCount()
        {
            return this.items.Count;
        }
    }
}
