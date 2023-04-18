using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Text.Json;
using System.Windows.Forms;

namespace LAB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("denmark");
            comboBox1.Items.Add("sweden");
            comboBox1.Items.Add("belgium");
            comboBox1.Items.Add("spain");
            comboBox1.Items.Add("portugal");
            comboBox1.Items.Add("ireland");
            comboBox1.Items.Add("luxembourg");
            comboBox1.Items.Add("norway");
            comboBox1.Items.Add("finland");
            comboBox1.Items.Add("switzerland");
            comboBox1.Items.Add("czech");
            comboBox1.Items.Add("italy");
            comboBox1.Items.Add("poland");
            comboBox1.Items.Add("malta");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string country = comboBox1.Text;

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://beers-list.p.rapidapi.com/beers/" + country),
                Headers =
                {
                    { "X-RapidAPI-Key", "d361e39900msh20aad5fcb88d582p1d544ejsn8211184a440f" },
                    { "X-RapidAPI-Host", "beers-list.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                textBox1.Text = body;
                var json = JsonSerializer.Deserialize<List<Beer>>(body);
                listBox1.Items.Clear();
                foreach (Beer beer in json)
                    listBox1.Items.Add(beer);
            }

        }
    }
}