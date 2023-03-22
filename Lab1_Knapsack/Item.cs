using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Knapsack
{
    internal class Item
    {
        private int value;
        private int weight;
        private int index;

        public Item(int value, int weight, int index)
        {
            this.value = value;
            this.weight = weight;
            this.index = index;
        }

        public float GetRatio()
        {
            return (float)value / (float)weight;
        }

        public override string ToString()
        {
            return this.index.ToString() + ". v: "+ this.value.ToString() + " w: " + this.weight.ToString() + " r: " + this.GetRatio().ToString();
        }

        public int GetWeight() { return this.weight; }
        public int GetValue() { return this.value; }
        public void SetWeight(int weight) { this.weight = weight;}
        public void SetValue(int value) { this.value = value; }
        public int GetIndex() { return this.index; }
        public void SetIndex(int index) { this.index = index;}

    }
}
