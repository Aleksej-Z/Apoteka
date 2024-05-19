using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka
{
    internal class Proizvod
    {
        #region osobine
        private int id;
        private string naziv;
        private string proizvodjac;
        private int kolicina;
        private double cena;
        #endregion
        #region seteri i geteri
        public int Id { get => id; set => id = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Proizvodjac { get => proizvodjac; set => proizvodjac = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        public double Cena { get => cena; set => cena = value; }
        #endregion
        #region konstruktori
        public Proizvod(int id, string naziv, string proizvodjac, int kolicina, double cena)
        {
            this.id = id;
            this.naziv = naziv;
            this.proizvodjac = proizvodjac;
            this.kolicina = kolicina;
            this.cena = cena;
        }
        #endregion
        #region funkcije
        public string UFajl()
        {
            return id.ToString() + ";" + naziv + ";" + proizvodjac + ";" + kolicina.ToString() + ";" + cena.ToString();
        }

        public string[] Zadatagridview()
        {
            string[] red = { id.ToString(), naziv, proizvodjac, kolicina.ToString(), cena.ToString()};
            return red;
        }
        public string ZaListBox()
        {
            return id.ToString() + " | " + naziv + " | " + proizvodjac + " | " + kolicina.ToString() + " | " + cena.ToString();
        }

        public string ZaListBoxBezID()
        {
            return naziv + " | " + proizvodjac + " | " + kolicina.ToString() + " | " + cena.ToString();
        }

        public string Nazivzp()
        {
            return naziv;
        }

        public int Idp()
        { 
            return id; 
        }
        #endregion
    }
}
