using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAgricole
{
    
    internal class Culture
    {
        #region Attributs, Propriétés et Constructeur
        private int identifiantCulture;
        private double numeroParcelle;
        private int codeProduction;
        private double coordonnées;
        private DateOnly dateDebut;
        private DateOnly dateFin;
        private double quantiteRecoltee;

        public int numeroIdentifiantCulture { get => identifiantCulture; set => identifiantCulture = value; }
        public double NumeroDeParcelle { get => numeroParcelle; set => numeroParcelle = value; }
        public int CodeDeProduction { get => codeProduction; set => codeProduction = value; }
        public double Coordonnées{ get => coordonnées; set => coordonnées = value; }
        public DateOnly DateDeDebut { get => dateDebut; set => dateDebut = value; }
        public DateOnly DateDeFin { get => dateFin; set => dateFin = value; }
        public double QuantiteRecoltee { get => quantiteRecoltee; set => quantiteRecoltee = value; }

        public Culture(int identifiantCulture, double numeroParcelle, int codeProduction, double coordonnées, DateOnly dateDebut, DateOnly dateFin, double quantiteRecoltee)
        {
            //On met 'this' pour faire référence aux attributs de la classe
            this.identifiantCulture = identifiantCulture;
            this.numeroParcelle = numeroParcelle;
            this.codeProduction = codeProduction;
            this.coordonnées = coordonnées;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            this.quantiteRecoltee = quantiteRecoltee;
        }
        #endregion
    }
}
