using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Test_1")]

namespace Lab1_Knapsack
{
    internal class Backpack
    {
        public List<Item> items;
        public int max_weight;
        public int act_weight;

        public Backpack(int weight)
        {
            items = new List<Item>();
            act_weight = 0;
            max_weight = weight;
        }

        public override string ToString()
        {
            string str = "";
            foreach (Item item in this.items)
            {
                str += item.ToString() + "\n";
            }
            int value = this.GetValue();
            float ratio = this.GetRatio();
            
            str += "weight: " + act_weight.ToString();
            str += " value: " + value.ToString();
            str += " ratio: " + ratio.ToString();
            str += "\nItems collected: " + items.Count.ToString();
            
            return str;
        }

        public int GetValue()
        {
            int value = 0;
            foreach (Item item in this.items)
            {
                value += item.GetValue();
            }
            return value;
        }

        public float GetRatio()
        {
            return (float)this.GetValue() / (float)act_weight;
        } 
    }
}
