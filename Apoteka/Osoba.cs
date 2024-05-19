using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka
{
    internal class Osoba
    {
        #region osobine
        private string ime;
        private string prezime;
        private string jmbg;
        private string bzk;
        #endregion
        #region seterii geteri
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Jmbg { get => jmbg; set => jmbg = value; }
        public string Bzk { get => bzk; set => bzk = value; }
        #endregion
        #region konstruktori
        public Osoba(string ime, string prezime, string jmbg, string bzk)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.bzk = bzk;
        }
        #endregion
    }
}
