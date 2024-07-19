using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestionAgricole
{
    internal class Parcelle
    {
        #region Attributs, Propriétés et Constructeur
        // Attributs
        private int numeroParcelle;
        private double surface;
        private string nomParcelle;
        private string coordonnées;

        // Propriétés
        public int NumeroParcelle { get => NumeroParcelle; set => NumeroParcelle = value; }
        public double Surface { get => Surface; set => Surface = value; }
        public string NomParcelle { get => NomParcelle; set => NomParcelle = value; }
        public string Coordonnées { get => Coordonnées; set => Coordonnées = value; }

        //Constructeur
        public Parcelle(int numeroDeParcelle, double surfaceDeParcelle, string nomDeLaParcelle, string coordonnéesParcelle)
        {
            numeroParcelle = numeroDeParcelle;
            surface = surfaceDeParcelle;
            nomParcelle = nomDeLaParcelle;
            coordonnées = coordonnéesParcelle;
        }
        #endregion
    }
}
