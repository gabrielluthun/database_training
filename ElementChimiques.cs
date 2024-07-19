using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAgricole
{
    internal class ElementChimiques
    {
        #region Attributs, Propriétés et Constructeur
        private string codeElement; //char limité à 5 caractères
        private string un; //char limité à 20 caractères
        private string libelleElement; //char limité à 20 caractères

        public string CodeElement { get => codeElement; set => codeElement = value; }
        public string Un { get => un; set => un = value; }
        public string LibelleElement { get => libelleElement; set => libelleElement = value; }

        public ElementChimiques(string codeElement, string un, string libelleElement)
        {
            this.codeElement = codeElement;
            this.un = un;
            this.libelleElement = libelleElement;
        }
        #endregion
    }
}
