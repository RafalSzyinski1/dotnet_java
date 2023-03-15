using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Item
    {
        int value;
        int weight;
        int index;

        public Item(int value, int weight, int index)
        {
            this.value = value;
            this.weight = weight;
            this.index = index;
        }

        public override string ToString()
        {
            return "i: " + this.index.ToString() + " v: " + this.value.ToString() + " w: " + this.weight.ToString();
        }

        public float GetRatio()
        {
            return (float)this.value / (float)this.weight;
        }

        public int GetWeight() 
        { 
            return this.weight;
        }

        public int GetValue()
        {
            return this.value;
        }
    }
}
