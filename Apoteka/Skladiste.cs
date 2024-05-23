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
    public partial class Skladiste : Form
    {
        public Skladiste()
        {
            InitializeComponent();
        }
        
        #region potrebni parametri
        Proizvod[] Proizvodi = new Proizvod[2000];
        int n = 0;
        double cena_ukupna = 0;
        const int b = 5;
        public static string cenatb;
        #endregion
        #region ucitavanje forme
        private void Skladiste_Load_1(object sender, EventArgs e)
        {
            #region citanje podataka iz fajla
            try
            {
                StreamReader f = new StreamReader("Proizvodi.txt");
                while (!f.EndOfStream)
                {
                    string linija = f.ReadLine();
                    string[] ProizvodInfo = linija.Split(';');
                    Proizvod p = new(int.Parse(ProizvodInfo[0]), ProizvodInfo[1], ProizvodInfo[2], int.Parse(ProizvodInfo[3]), double.Parse(ProizvodInfo[4]));
                    Proizvodi[n] = p;
                    n++;
                }
                f.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Some error occured " + ex.Message + ex.Source);
            }
            #endregion
            #region unos u tabelu
            while (dataGridView2.Rows.Count > 1)
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count - 2);
            }
            
            for (int i = 0; i < n; i++)
            {
                dataGridView2.Rows.Add(Proizvodi[i].Zadatagridview());
            }
            #endregion
            #region dodavanje u listbox
            listBox1.Items.Clear();
            for (int i = 0; i < n; i++)
            {
                listBox1.Items.Add(Proizvodi[i].ZaListBox());
            }
            #endregion
        }
        #endregion
        #region osvezavanje
            #region funkcija za osvezavanje listbox-a
            private void OsvezavanjeListBox()
            {
                listBox1.Items.Clear();
                for (int i = 0; i < n; i++)
                {
                    if (Proizvodi[i] != null)
                    {
                        listBox1.Items.Add(Proizvodi[i].ZaListBox());
                    }   
                }
            }
            #endregion
            #region funkcija za osvezavanje DataGridView tabele
            private void OsvezavanjeTabele()
            {
                while (dataGridView2.Rows.Count > 1)
                {
                    dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count - 2);
                }

                for (int i = 0; i < n; i++)
                {
                    if (Proizvodi[i] != null)
                    {
                        dataGridView2.Rows.Add(Proizvodi[i].Zadatagridview());
                    }
                }
            }
            #endregion
        #endregion
        #region pretraga proizvoda za datagridview
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string tekst = textBox1.Text;
            while (dataGridView2.Rows.Count > 1)
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count - 2);
            }

            for (int i = 0; i < n; i++)
            {
                if (Proizvodi[i].Nazivzp() != null)
                {
                    if (Proizvodi[i].Nazivzp().ToLower().StartsWith(tekst.ToLower()))
                    {
                        dataGridView2.Rows.Add(Proizvodi[i].Zadatagridview());
                    }
                }
            }

        }
        #endregion
        #region cuvanje podataka pri zatvaranju forme prilikom pritiska dugmeta
        private void Skladiste_KeyDown(object sender, KeyEventArgs e)
        {
            #region Delete sredjivanje
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            #endregion
            if (e.KeyCode == Keys.Escape)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter("Proizvodi.txt"))
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (Proizvodi[i] != null)
                            {
                                sw.WriteLine(Proizvodi[i].UFajl());
                            }
                        }
                        sw.Close();
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Some error occured ");
                }

                try
                {
                    //ovde si sklonio pravljenje nove forme
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some error occured " + ex.Message + ex.Source);
                }
            }
        }
        #endregion
        #region dodavanje i uklanjanje proizvoda sa stanja
        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.SelectedCells[1].Value.ToString() + " " + dataGridView2.SelectedCells[2].Value.ToString();
        }
        #region dodavanje
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != null && textBox3.Text != null && int.Parse(textBox3.Text) > 0)
                {
                    //pronalazimo odgovarajuci Proizvod i povecavamo njegovu vrednost za unesenu u textbox3
                    int ID = int.Parse(dataGridView2.SelectedCells[0].Value.ToString());
                    for (int i = 0; i < n; i++)
                    {
                        if (ID == Proizvodi[i].Idp())
                        {
                            Proizvodi[i].Kolicina += int.Parse(textBox3.Text);
                        }
                    }
                    //osvezavamo tabelu 2
                    while (dataGridView2.Rows.Count > 1)
                    {
                        dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count - 2);
                    }

                    for (int i = 0; i < n; i++)
                    {
                        dataGridView2.Rows.Add(Proizvodi[i].Zadatagridview());
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Greska! Niste izabrali proizvod ili uneli kolicinu!");
            }
        }
        #endregion
        #region uklanjanje
        private void Uklonib_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != null && textBox3.Text != null && int.Parse(textBox3.Text) > 0)
                {
                    if (int.Parse(dataGridView2.SelectedCells[3].Value.ToString()) > int.Parse(textBox3.Text))
                    {
                        //pronalazimo odgovarajuci Proizvod i smanjujemo njegovu vrednost za unesenu u textbox3
                        int ID = int.Parse(dataGridView2.SelectedCells[0].Value.ToString());
                        for (int i = 0; i < n; i++)
                        {
                            if (ID == Proizvodi[i].Idp())
                            {
                                Proizvodi[i].Kolicina -= int.Parse(textBox3.Text);
                            }
                        }
                        //osvezavamo tabelu 2
                        while (dataGridView2.Rows.Count > 1)
                        {
                            dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count - 2);
                        }

                        for (int i = 0; i < n; i++)
                        {
                            dataGridView2.Rows.Add(Proizvodi[i].Zadatagridview());
                        }
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Ne mozete ukloniti vise proizvoda nego sto ima na stanju!");
                        textBox3.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Greska! Niste izabrali proizvod ili uneli kolicinu!");
            }
        }
        #endregion
        #endregion
        #region cuvanje podataka prilikom zatvaranja forme rucno
        private void Skladiste_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("Proizvodi.txt"))
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (Proizvodi[i].Id != null)
                        {
                            sw.WriteLine(Proizvodi[i].UFajl());
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
        #region dodavanje novog proizvoda
        private void Dodajnovibutton_Click(object sender, EventArgs e)
        {
            #region provera unosa u sva tri polja
            string naziv="", proizvodjac="";
            double cena=0;
            try
            {
                naziv = Nazivnovogbox.Text;
            }
            catch (Exception) 
            {
                MessageBox.Show("Unesite naziv novog proizvoda!");
                Nazivnovogbox.Text = null;
            }
            try
            {
                proizvodjac = Proizvodjacnovogbox.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Unesite naziv novog proizvodjaca!");
                Proizvodjacnovogbox.Text = null;
            }
            try
            {
                cena = Double.Parse(Cenanovogbox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Unesite cenu novog proizvoda!");
                Cenanovogbox.Text = null;
                cena = 0;
            }
            #endregion
            #region unos novog proizvoda u niz proizvoda
            if (naziv != null && proizvodjac != null && cena > 0)
            {
                Proizvodi[n] = new Proizvod(Proizvodi[n - 1].Id + 1, naziv, proizvodjac, 0, cena);
                n++;
                //osvezavamo tabelu 2
                while (dataGridView2.Rows.Count > 1)
                {
                    dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count - 2);
                }

                for (int i = 0; i < n; i++)
                {
                    dataGridView2.Rows.Add(Proizvodi[i].Zadatagridview());
                }
                //cistimo polja za unos novih proizvoda
                Nazivnovogbox.Text = "";
                Proizvodjacnovogbox.Text = "";
                Cenanovogbox.Text = "";

                #region osvezavanje tabele
                while (dataGridView2.Rows.Count > 1)
                {
                    dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count - 2);
                }

                for (int i = 0; i < n; i++)
                {
                    dataGridView2.Rows.Add(Proizvodi[i].Zadatagridview());
                }
                #endregion
                OsvezavanjeListBox();
            }
            else
            {
                MessageBox.Show("Morate uneti sve potrebne podatke za novi proizvod!");
            }
            #endregion
        }
        #endregion
        #region pretraga proizvoda za brisanje ili promenu cene
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string tekst = textBox7.Text;
            listBox1.Items.Clear();

            for (int i = 0; i < n; i++)
            {
                if (Proizvodi[i].Naziv != null)
                {
                    if (Proizvodi[i].ZaListBoxBezID().ToLower().StartsWith(tekst.ToLower()))
                    {
                        listBox1.Items.Add(Proizvodi[i].ZaListBox());
                    }
                }
            }
        }
        #endregion
        #region prikaz proizvoda za brisanje
        private void listBox1_Click(object sender, EventArgs e)
        { 
            string izabrani_p = listBox1.SelectedItem.ToString();
            textBox4.Text = izabrani_p.Split('|')[1];
            
        }
        #endregion
        #region brisanje
        private void Brisanjeb_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                try
                {
                    textBox4.Text = "";
                    string izabrani_p = listBox1.SelectedItem.ToString();
                    #region pretrazujemo niz proizvoda i postavljamo vrednost datog proizvoda na null kako bismo ga izbrisali
                    int ID = int.Parse(izabrani_p.Split('|')[0]);
                    for (int i = 0; i < n; i++)
                    {
                        if (ID == Proizvodi[i].Id)
                        {
                            Proizvodi[i] = null;
                            n--;
                        }
                    }
                    #endregion
                    OsvezavanjeTabele();
                    OsvezavanjeListBox();
                }
                catch (Exception)
                {
                    MessageBox.Show("Izaberite proizvod koji zelite da obrisete!");
                }
            }
        }
        #endregion
        #region promena cene
        private void Promenib_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                try
                {
                    if (Double.Parse(textBox5.Text.ToString()) > 0)
                    {
                        string izabrani_p = listBox1.SelectedItem.ToString();
                        #region pretrazujemo niz proizvoda i menjamo cenu
                        int ID = int.Parse(izabrani_p.Split('|')[0]);
                        for (int i = 0; i < n; i++)
                        {
                            if (ID == Proizvodi[i].Id)
                            {
                                Proizvodi[i].Cena = Double.Parse(textBox5.Text.ToString());
                            }
                        }
                        #endregion
                        OsvezavanjeTabele();
                        OsvezavanjeListBox();
                        textBox5.Text = "";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Unesite novu cenu u odgovarajuce polje!");
                    textBox5.Text = "";
                }
            }
        }
        #endregion
    }
}
