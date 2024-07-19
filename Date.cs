using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAgricole
{
    #region Attributs, Propriétés et Constructeur
    internal class Date
    {
        private DateOnly date;

        public DateOnly DATE { get => date; set => date = value; }

        public Date(DateOnly date)
        {
            this.date = date;
        }
    }
        #endregion
}
