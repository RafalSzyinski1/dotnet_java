using Lab1_Knapsack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number = int.Parse(BoxNumber.Text);
            int seed = int.Parse(BoxSeed.Text);
            int weight = int.Parse(BoxWeight.Text);
            Knapsack knapsack = new Knapsack(number,seed);
            BoxKnapsack.Text = knapsack.ToString();
            Backpack backpack = new Backpack(weight);
            knapsack.steal(backpack);
            BoxBackpack.Text = backpack.ToString();
        }

        private void BoxWeight_TextChanged(object sender, EventArgs e)
        {
           if (!int.TryParse(BoxWeight.Text, out int result))
            {
                button1.Enabled = false;

            }
            else button1.Enabled = true;
        }

        private void BoxNumber_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(BoxNumber.Text, out int result))
            {
                button1.Enabled = false;

            }
            else button1.Enabled = true;

        }

        private void BoxSeed_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(BoxSeed.Text, out int result))
            {
                button1.Enabled = false;

            }
            else button1.Enabled = true;

        }





    }
}
