

namespace GestionAgricole
{
    internal class Engrais
    {
        private int idEngrais;
        private string Unite;
        private string nomEngrais;
        public int IdEngrais { get => idEngrais; set => idEngrais = value; }
        public string UNITE { get => Unite; set => Unite = value; }
        public string NomEngrais { get => nomEngrais; set => nomEngrais = value; }

        public Engrais(int idEngrais, string Unite, string nomEngrais)
        {
            this.idEngrais = idEngrais;
            this.Unite = Unite;
            this.nomEngrais = nomEngrais;
        }

    }
}
