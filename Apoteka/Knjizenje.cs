using System;
using System.Collections;
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
    public partial class Knjizenje : Form
    {
        public Knjizenje()
        {
            InitializeComponent();
        }
        #region definisanje potrebnih lista i kontruktori za prihvatanje tih lista iz Form1
        List<string> nazivi = new List<string>();
        List<int> br_proizvoda = new List<int>();
        List<double> cene = new List<double>();

        public Knjizenje(List<string> StrList, List<int> IntList, List<double> DblList)
        {
            InitializeComponent();
            nazivi = StrList;
            br_proizvoda = IntList;
            cene = DblList;
        }
        double kusur = 0;
        #endregion
        #region ucitavanje nove forme
        private void Knjizenje_Load(object sender, EventArgs e)
        {
            Cenabox.Text = e_prodaja.cenatb;
        }
        #endregion
        #region racun(izgled racuna)
        private void Racun()
        {
            string billMessage = "Fiskalni racun\n" +
                                 "-----------------------------------------------------------------\n" +
                                 "| Proizvod                        | Kolicina | Cena   | Ukupno |\n" +
                                 "-----------------------------------------------------------------\n";

            double sve_ukupno = 0; //ukupna cena celog racuna
            for (int i = 0; i < nazivi.Count; i++)
            {
                double p_ukupno = cene[i] * br_proizvoda[i]; // ukupna cena za dati proizvod
                                                             // Adjusted spacing for fixed-width format
                string proizvodColumn = nazivi[i].Substring(0, Math.Min(nazivi[i].Length, 25)).PadRight(25);
                string kolicinaColumn = br_proizvoda[i].ToString().PadRight(9);
                string cenaColumn = cene[i].ToString("F2").PadRight(6);
                string ukupnoColumn = p_ukupno.ToString("F2").PadRight(6);

                billMessage += $"| {proizvodColumn} | {kolicinaColumn} | {cenaColumn} | {ukupnoColumn} |\n";
                sve_ukupno += p_ukupno;
            }

            billMessage += "---------------------------------------------------------------\n" +
                           $"| Ukupno: {sve_ukupno,-7:F2}                                                    |\n" +
                           "---------------------------------------------------------------\n" +
                           $"| Kusur:  {kusur,-7:F2}                                                         |\n" +
                           "---------------------------------------------------------------\n" +
                           "Hvala na kupovini sa nama!";

            // Display bill using MessageBox
            MessageBox.Show(billMessage, "Fiskalni racun apoteke", MessageBoxButtons.OK);
        }
        #endregion
        #region slucaj kartica
        private void button1_Click(object sender, EventArgs e)
        {
            Racun();//pustamo racun pomocu funkcije Racun()
            kusur = 0;
            Gotovinabox.Text = "";
            Visible = false;
        }
        #endregion
        #region slucaj gotovina
        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                double sve_ukupno = 0; //ukupna cena celog racuna
                for (int i = 0; i < nazivi.Count; i++)
                {
                    double p_ukupno = cene[i] * br_proizvoda[i]; // ukupna cena za dati proizvod
                    sve_ukupno += p_ukupno;
                }
                kusur = Double.Parse(Gotovinabox.Text) - sve_ukupno;
                if (kusur >= 0)
                {
                    Racun();//pustamo racun pomocu funkcije Racun()
                    Gotovinabox.Text = "";
                    Visible = false;
                }
                else 
                {
                    MessageBox.Show("Niste uneli dovoljnu kolicinu novca");
                    Gotovinabox.Text = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unesite kolicinu novca ukoliko placate gotovinom ili pritisnite polje kartica ukoliko placate karticom");
                Gotovinabox.Text = "";
            }
        }
        #endregion
        #region pustanje racuna
        private void Knjizenje_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (Kusurbox.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Racun();//pustamo racun pomocu funkcije Racun();
                    Gotovinabox.Text = "";
                    Visible = false;
                }
            }*/
            #region Delete sredjivanje
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            #endregion
        }
        #endregion
    }
}
