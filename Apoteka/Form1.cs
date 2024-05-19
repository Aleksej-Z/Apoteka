using System;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;

namespace Apoteka
{
    public partial class e_prodaja : Form
    {
        public e_prodaja()
        {
            InitializeComponent();
        }
        #region potrebni parametri
        Proizvod[] Proizvodi = new Proizvod[2000];
        public static int n = 0;
        double cena_ukupna = 0;
        public static int b = 5;
        public static string cenatb;
        public static string [] Proizvodi1 = new string[2000];
        #endregion
        #region ucitavanje forme
        private void Apoteka_Load(object sender, EventArgs e)
        {
            #region citanje podataka iz fajla
                try
                {
                n = 0;
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
            #region ukoliko je koriscen recept
            try
            {
                Random rand = new Random();
                int number = rand.Next(0, 100);

                for (int i = 0; i < n; i++)
                {
                    if(e_recepti.izabrani == Proizvodi[i].Naziv)
                    {
                        dataGridView1.Rows.Add(Proizvodi[i].Id.ToString(), Proizvodi[i].Naziv, Proizvodi[i].Proizvodjac, Proizvodi[i].Kolicina.ToString(), (Proizvodi[i].Cena- Proizvodi[i].Cena*number/100).ToString());
                        cena_ukupna = Math.Round((Proizvodi[i].Cena - Proizvodi[i].Cena * number / 100), 2);
                        CenaBox.Text = cena_ukupna.ToString();
                        break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some error occured.");
            }
            #endregion
        }
        #endregion
        #region cuvanje podataka pri zatvaranju forme
        private void Apoteka_FormClosed(object sender, FormClosedEventArgs e)
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
        }
        #endregion
        #region pritisci tastera
        private void Apoteka_KeyDown(object sender, KeyEventArgs e)
        {
            #region Delete sredjivanje
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            #endregion
            #region dodavanje u tabelu 1
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string[] pomniz = new string[b];

                    //ukoliko vise nema izabranih proizvoda na stanju
                    if (dataGridView2.SelectedCells[3].Value != null && int.Parse(dataGridView2.SelectedCells[3].Value.ToString()) != 0)
                    {
                        //sve vrednosti ubacujemo u pomocni niz
                        for (int i = 0; i < b; i++)
                        {
                            if (dataGridView2.SelectedCells[i].Value.ToString() != null)
                            {
                                pomniz[i] = dataGridView2.SelectedCells[i].Value.ToString();
                            }
                        }

                        //vrednosti iz pomocnog niza prebacujemo u novu tabelu pri cemu smanjujemo kolicinu datog proizvoda za jedan
                        dataGridView1.Rows.Add(pomniz[0], pomniz[1], pomniz[2], int.Parse(pomniz[3]) - 1, pomniz[4]);

                        //pretrazujemo niz proizvoda i smanjujemo kolicinu izabranog proizvoda za 1
                        int ID = int.Parse(pomniz[0]);
                        for (int i = 0; i < n; i++)
                        {
                            if (ID == Proizvodi[i].Idp())
                            {
                                Proizvodi[i].Kolicina--;
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

                        //cistimo textbox
                        textBox1.Text = "";

                        //racunamo ukupnu cenu i ispisujemo je u CenaBox
                        cena_ukupna += double.Parse(pomniz[4]);

                        CenaBox.Text = cena_ukupna.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Izabranog proizvoda nema na stanju!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some error occured " + ex.Message + ex.Source);
                }
            }
            #endregion
            #region brisanje izabranog proizvoda iz tabele 1
            else if (e.KeyCode == Keys.F1)
            {
                try
                {
                    string[] pomniz = new string[b];

                    //ukoliko nista nije izabrano
                    if (dataGridView1.SelectedCells[3].Value != null)
                    {
                        //sve vrednosti ubacujemo u pomocni niz
                        for (int i = 0; i < b; i++)
                        {
                            if (dataGridView1.SelectedCells[i].Value.ToString() != null)
                            {
                                pomniz[i] = dataGridView1.SelectedCells[i].Value.ToString();
                            }
                        }
                        //pretrazujemo niz proizvoda i povecavamo kolicinu izabranog proizvoda za 1
                        int ID = int.Parse(pomniz[0]);
                        for (int i = 0; i < n; i++)
                        {
                            if (ID == Proizvodi[i].Idp())
                            {
                                Proizvodi[i].Kolicina++;
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

                        //racunamo ukupnu cenu i ispisujemo je u CenaBox
                        cena_ukupna -= double.Parse(pomniz[4]);
                        if (cena_ukupna == 0)
                        {
                            CenaBox.Text = "0.00";
                        }
                        else
                        {
                            CenaBox.Text = cena_ukupna.ToString();
                        }

                        //cistimo textbox
                        textBox1.Text = "";

                        //uklanjamo izabrani red
                        int red = dataGridView1.CurrentCell.RowIndex;
                        dataGridView1.Rows.RemoveAt(red);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some error occured " + ex.Message + ex.Source);
                }
                if (cena_ukupna < 0)
                {
                    CenaBox.Text = "0.00";
                }
            }
            #endregion
            #region brisanje svega iz tabele 1
            else if (e.KeyCode == Keys.Escape)
            {
                try
                {
                    //brisemo sve iz tabele 1
                    string[] pomniz = new string[5];
                    for (int j = 0, br = dataGridView1.Rows.Count - 1; j < br; j++)
                    {
                        try
                        {
                            //uzimamo podatke iz izabranog reda i smestamo ih u niz
                            if (dataGridView1.Rows[j].Cells[0].Value.ToString() != null)
                            {
                                for (int i = 0; i < b; i++)
                                {
                                    pomniz[i] = dataGridView1.Rows[j].Cells[i].Value.ToString();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + ex.Source);
                        }
                        //pretrazujemo niz proizvoda i povecavamo kolicinu izabranog proizvoda za 1
                        int ID = int.Parse(pomniz[0]);
                        for (int i = 0; i < n; i++)
                        {
                            if (ID == Proizvodi[i].Idp())
                            {
                                Proizvodi[i].Kolicina++;
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
                    }
                    //brisemo sve iz tabele 1
                    while (dataGridView1.Rows.Count > 1)
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                    }
                    cena_ukupna = 0;
                    CenaBox.Text = "0.00";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some error occured " + ex.Message + ex.Source);
                }
            }
            #endregion
            #region knjizenje
            else if (e.KeyCode == Keys.F12)
            {
                try
                {
                    if (Double.Parse(CenaBox.Text) != 0)
                    {

                        
                        List<string> nazivi = new List<string>();
                        List<int> br_proizvoda = new List<int>();
                        List<double> cene = new List<double>();
                        string str_cena = "";
                        double dbl_cena = 0;

                        //nazivi, cene i br proizvoda su pom liste, uzimamo iz datagridview_1 ubacujemo u pom nizove
                        for (int i = 0, br = dataGridView1.Rows.Count - 1; i < br; i++)//mozda ce biti problem sa duzinom dgv1, pripazi na to
                        {
                            if (dataGridView1.Rows[i].Cells[1].Value != null)//proveravamo da nije prazno polje
                            {
                                if (!nazivi.Contains(dataGridView1.Rows[i].Cells[1].Value.ToString()))
                                {
                                    nazivi.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                                    br_proizvoda.Add(1);
                                    cene.Add(Double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));//uzimamo vrednost cene, konvertujemo je i dodajemo u listu cene
                                }
                                else 
                                {
                                    int ind = nazivi.IndexOf(dataGridView1.Rows[i].Cells[1].Value.ToString());
                                    br_proizvoda[ind] += 1;//dodajemo 1 za odg proizvod
                                }
                            }
                        }

                        #region prosledjivanje lista u formu knjizenje i otvaranje forme knjizenje
                        Knjizenje formKnj = new Knjizenje(nazivi, br_proizvoda, cene);
                        formKnj.Show();
                        #endregion
                        #region sredjivanje forme1 nakon zavrsetka jednog racuna
                        //uzimamo vrednost cene koja treba da se prebaci na novi prozor
                        cenatb = CenaBox.Text;

                        //brisemo sve iz tabele 1
                        while (dataGridView1.Rows.Count > 1)
                        {
                            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        }

                        //vracamo vrednost ukpne cene na 0
                        cena_ukupna = 0;
                        CenaBox.Text = cena_ukupna.ToString();
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Niste nista izabrali.");
                    }
                }
                catch (Exception)
                {
                }
            }
            #endregion
            #region otvaranje skladista
            else if (e.KeyCode == Keys.F2)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter("Proizvodi.txt"))
                    {
                        for (int i = 0; i < n; i++)
                        {
                            sw.WriteLine(Proizvodi[i].UFajl());
                        }
                        sw.Close();
                    }
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Some error occured ");
                }
                //pozivamo formu skaldiste i zatvaramo formu e_prodaja
                Form Skladiste = new Skladiste();
                Skladiste.Show();
                Hide();
            }
            #endregion
            #region recept
            else if (e.KeyCode == Keys.F3)
            {
                //pozivamo novi prozor
                Form e_recepti = new e_recepti();
                e_recepti.Show();
                Hide();
            }
            #endregion
            #region zatvaranje svega
            else if (e.KeyCode == Keys.F4)
            {
                Close();
            }
            #endregion
        }
        #endregion
        #region pretraga proizvoda
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
        #region promena smene
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "1")
            {
                button1.Text = "2";
            }
            else
            {
                button1.Text = "1";
            }
        }
        #endregion
    }
}