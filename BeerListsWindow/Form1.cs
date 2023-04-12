using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.SqlServer;
using lab2;

namespace BeerListsWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            country_list.Text = "All";
            show_box.SetItemChecked(0, true);
        }

        private async void gen_button_Click(object sender, EventArgs e)
        {
            List<Beer> list;
            if (country_list.Text == "All")
            {
                list = await new BeerList().GetList("");
            } 
            else
            {
                list = await new BeerList().GetList(country_list.Text);
            }

            beer_list.Items.Clear();

            foreach (Beer beer in list) 
            {
                string beer_text = "";

                if (show_box.GetItemChecked(0) == true)
                {
                    beer_text += "Name: " + beer.Title + "\t"; 
                }
                if (show_box.GetItemChecked(1) == true)
                {
                    beer_text += "Alcohol: " + beer.Alchool + "\t";
                }
                if (show_box.GetItemChecked(2) == true)
                {
                    beer_text += "Country: " + beer.Country + "\t";
                }
                if (show_box.GetItemChecked(3) == true)
                {
                    beer_text += "Description: " + beer.Description + "\t";
                }
                beer_text += Environment.NewLine;

                beer_list.Items.Add(beer_text);
            }
        }
    }
}
