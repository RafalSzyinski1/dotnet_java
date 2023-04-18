using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using NAudio.Wave;
using System.Threading;

namespace LAB2
{
    public partial class Form1 : Form
    {
        private BeerBase Base;
        bool music_play = true;
        Thread thread;

        public Form1()
        {
            InitializeComponent();


            thread = new Thread(music);
            thread.Start();


            Base = new BeerBase();
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
            bool country_not_downloaded = true;

            if (country == "")
            {
                textBox1.Text = "Nie poda³eœ kraju!";
                country_not_downloaded = false;
            }

            if (country_not_downloaded)
            {
                foreach (var beer in Base.Beers)
                {
                    if (beer.country == country)
                    {
                        textBox1.Text = "Kraj ju¿ jest pobrany!";
                        country_not_downloaded = false;
                        break;
                    }
                }

            }


            if (country_not_downloaded)
            {
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
                    List<Beer> json = JsonSerializer.Deserialize<List<Beer>>(body);
                    listBox1.Items.Clear();
                    foreach (Beer beer in json)
                    {
                        listBox1.Items.Add(beer);
                        beer.country = country;
                        Base.Add(beer);
                    }
                    Base.SaveChanges();

                    var piwko = Base.Beers.ToList();
                    foreach (var x in piwko)
                        listBox1.Items.Add(x);



                }



                textBox1.Text = "Lista Piw z kraju: " + country + " pobrana pomyœlnie!";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string country = comboBox1.Text;
            var piwko = Base.Beers.ToList();
            bool puste = true;
            foreach (var x in piwko)
                if (x.country == country)
                {
                    puste = false;
                    listBox1.Items.Add(x);
                }

            if (puste)
            {
                textBox1.Text = "Nie ma ¿adnych piw z " + country + " w bazie!!";
            }
            else
            {
                textBox1.Text = "Wyœwietlam piwa z kraju: " + country;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string country = comboBox1.Text;
            bool puste = true;

            foreach (var beer in Base.Beers)
            {
                if (beer.country == country)
                {
                    int a = beer.ID;
                    var s = Base.Beers.First(x => x.ID == a);
                    Base.Beers.Remove(s);
                    puste = false;
                }
            }
            Base.SaveChanges();

            if (puste)
            {
                textBox1.Text = "Nie ma nic do czyszczenia";
            }
            else
            {
                textBox1.Text = "Kraj wyczyszczony pomyœlnie";
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void music()
        {

            var audioFile = @"E:\6 sem\.NET JAVA\lab2\dotnet_java\LAB2\LAB2\Resources\harnas.mp3";

            using (var audioFileReader = new Mp3FileReader(audioFile))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFileReader);
                outputDevice.Play();

                while (outputDevice.PlaybackState == PlaybackState.Playing && music_play)
                {
                    System.Threading.Thread.Sleep(1);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zamkn¹æ program?", "PotwierdŸ zamkniêcie", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true; // Anuluj zamkniêcie programu
            }
            else
            {
                music_play = false;
            }

        }
    }
}