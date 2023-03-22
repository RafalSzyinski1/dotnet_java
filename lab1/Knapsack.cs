using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("TestKnapsack"), InternalsVisibleTo("KnapsackWindow")]

namespace lab1
{
    internal class KnapsackResult
    {
        List<Item> items;

        public KnapsackResult(List<Item> items)
        {
            this.items = items;
        }

        public int GetSumValues()
        {
            int result = 0;
            foreach (Item item in items)
                result += item.GetValue();

            return result;
        }

        public int GetSumWeights()
        {
            int result = 0;
            foreach (Item item in items)
                result += item.GetWeight();

            return result;
        }

        public override string ToString()
        {
            string str = "Items:" + Environment.NewLine;
            foreach (Item i in this.items)
            {
                str += i.ToString() + Environment.NewLine;
            }
            str += Environment.NewLine + 
                "Sum values: " + this.GetSumValues() + 
                Environment.NewLine + "Sum weights: " + this.GetSumWeights();

            return str;
        }
    }

    internal class Knapsack
    {
        List<Item> items;

        public Knapsack()
        {
            this.items = new List<Item>();
        }

        public Knapsack(int number, int seed)
        {
            this.items = new List<Item>();
            Random random = new Random(seed);
            for (int i = 0; i < number; i++)
                this.AddItem(new Item(random.Next(1, 10), random.Next(1, 10), i));
        }

        public void AddItem(Item item)
        {
            this.items.Add(item);
        }

        public KnapsackResult run(int volume)
        {
            this.items.Sort(delegate (Item lhs, Item rhs) { return lhs.GetRatio().CompareTo(rhs.GetRatio()); });
            this.items.Reverse();
            List<Item> result = new List<Item>();
            int sum_volume = 0;

            foreach (Item item in this.items)
            {
                int item_weight = item.GetWeight();
                if (sum_volume + item_weight > volume)
                    break;
                sum_volume += item_weight;
                result.Add(item);
                
            }

            return new KnapsackResult(result);
        }

        public override string ToString()
        {
            string str = "";
            foreach (Item item in this.items)
                str += item.ToString() + Environment.NewLine;
            return str;
        }
    }
}
