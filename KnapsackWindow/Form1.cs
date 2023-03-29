using lab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnapsackWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gen_button_Click(object sender, EventArgs e)
        {
            int num_of_items = (int)num_of_items_numeric.Value;
            int seed = (int)seed_numeric.Value;
            int knapsack_volume = (int)volume_numeric.Value;
            Knapsack knapsack = new Knapsack(num_of_items, seed);
            knapsack_box.Text = knapsack.ToString();
            output_box.Text = knapsack.run(knapsack_volume).ToString();
        }
    }
}
