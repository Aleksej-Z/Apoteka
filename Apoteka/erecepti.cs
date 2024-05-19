using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apoteka
{
    public partial class e_recepti : Form
    {
        public e_recepti()
        {
            InitializeComponent();
        }
        #region potrebni parametri
        Recept[] recepti = new Recept[1000];
        Osoba[] osobe = new Osoba[1000];
        public static string izabrani="";
        int r, o;
        #endregion
        #region ucitavanje forme
        private void erecepti_Load(object sender, EventArgs e)
        {
            #region citanje podataka iz fajla recepti
            try
            {
                r = 0;
                StreamReader re = new StreamReader("Recepti.txt");
                while (!re.EndOfStream)
                {
                    string linija = re.ReadLine();
                    string[] ReceptInfo = linija.Split(';');
                    recepti[r] = new Recept(int.Parse(ReceptInfo[0]), ReceptInfo[1], ReceptInfo[2]);
                    r++;
                }
                re.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Some error occured " + ex.Message + ex.Source);
            }
            #endregion
            #region citanje podataka iz fajla osobe
            try
            {
                o = 0;
                StreamReader os = new StreamReader("Osobe.txt");
                while (!os.EndOfStream)
                {
                    string linijaa = os.ReadLine();
                    string[] OsobaInfo = linijaa.Split(';');
                    osobe[o] = new Osoba(OsobaInfo[0], OsobaInfo[1], OsobaInfo[2], OsobaInfo[3]);
                    o++;
                }
                os.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Some error occured " + ex.Message + ex.Source);
            }
            #endregion
        }
        #endregion
        #region zatvaranje forme
        private void e_recepti_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ukoliko je neki recept iskoriscen treba da se skloni iz liste recepata i zatim da se ti novi podaci sacuvaju u fajl recepti
            bool pronadjen = false;
            int br = 0;
            try
            {
                if (dataGridView1.SelectedCells[1].Value != null)
                {
                    while (pronadjen == false && br < o)
                    {
                        if (dataGridView1.SelectedCells[0].Value.ToString() == recepti[br].Id_recepta.ToString())
                        {
                            recepti[br] = null;
                            pronadjen = true;
                        }
                        br++;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nista niste izabrali.");
            }
            try
            {
                using (StreamWriter sw = new StreamWriter("Recepti.txt"))
                {
                    for (int i = 0; i < r; i++)
                    {
                        if (recepti[i] != null)
                        {
                            sw.WriteLine(recepti[i].UFajl());
                        }
                    }
                    sw.Close();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Some error occured ");
            }
            Form eprodaja = new e_prodaja();
            eprodaja.Show();
        }
        #endregion
        #region izabrani lek ide u eprodaju i dobija popust
        private void e_recepti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 'R')
            {
                try
                {
                    if (dataGridView1.SelectedCells[1].Value != null)
                    {
                        izabrani = dataGridView1.SelectedCells[1].Value.ToString();
                    }
                    Close();//mozda ces trebati ovoda sklonis, ali onda stavi ovde deo sa cuvanjem podataka kad se iskljucuje forma
                }
                catch(Exception)
                {
                    MessageBox.Show("Izaberite recept!");
                    Close();
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 'R')
            {
                try
                {
                    if (dataGridView1.SelectedCells[1].Value != null)
                    {
                        izabrani = dataGridView1.SelectedCells[1].Value.ToString();
                    }
                    Close();//mozda ces trebati ovoda sklonis, ali onda stavi ovde deo sa cuvanjem podataka kad se iskucuje forma
                }
                catch (Exception)
                {
                    MessageBox.Show("Izaberite recept!");
                    Close();
                }
            }
        }
        #endregion
        #region provera bzk-a
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            try
            {
                //brisemo sve od ranije
                while (dataGridView1.Rows.Count > 1)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                }
                //prolazimo kroz niz osoba kako bismo pronasli osobu sa izabranim bzk_e
                bool pronadjen = false;
                int br = 0;
                while (pronadjen == false && br < o)
                {
                    //MessageBox.Show("Ovo je uneseni bzk ",textBox1.Text);
                    //MessageBox.Show("Ovo je bzk iz pretrage ",osobe[br].Bzk);
                    if (textBox1.Text == osobe[br].Bzk)
                    {
                        textBox2.Text = osobe[br].Jmbg;
                        textBox3.Text = osobe[br].Ime;
                        textBox4.Text = osobe[br].Prezime;
                        pronadjen = true;
                    }
                    br++;
                }
                if (!pronadjen)
                {
                    MessageBox.Show("Nepostojeci broj zdravstvene knjizice!");
                }
                //prolazimo kroz ceo niz recepata zato sto moze biti vise recepata za jednu osobu
                for (int i = 0; i < r; i++)
                {
                    if (textBox1.Text == recepti[i].Bzk)
                    {
                        dataGridView1.Rows.Add(recepti[i].Zadatagridview());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nepostojeci broj zdravstvene knjizice!");
            }
        }
        #endregion
    }
}
