using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apoteka
{
    internal class Recept
    {
        #region osobine
        private int id_recepta;
        private string lek_naziv;
        private string bzk;
        #endregion
        #region seteri i geteri
        public int Id_recepta { get => id_recepta; set => id_recepta = value; }
        public string Lek_naziv { get => lek_naziv; set => lek_naziv = value; }
        public string Bzk { get => bzk; set => bzk = value; }
        #endregion
        #region konstruktori
        public Recept(int id_recepta, string lek_naziv, string bzk)
        {
            this.id_recepta = id_recepta;
            this.lek_naziv = lek_naziv;
            this.bzk = bzk;
        }
        #endregion
        #region funkcije
        public string[] Zadatagridview()
        {
            string[] red = { id_recepta.ToString(), lek_naziv, bzk};
            return red;
        }
        public string UFajl()
        {
            return id_recepta.ToString()+";"+lek_naziv+";"+bzk;
        }
        #endregion
    }
}
