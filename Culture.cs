using MySql.Data.MySqlClient;
using GestionAgricole.App.Database;

namespace GestionAgricole
{
    
    internal class Culture
    {
        #region Attributs, Propriétés et Constructeur
        private int identifiantCulture;
        private double numeroParcelle;
        private int codeProduction;
        private double coordonnées;
        private DateTime dateDebut;
        private DateTime dateFin;
        private decimal quantiteRecoltee;

        public int NumeroIdentifiantCulture { get => identifiantCulture; set => identifiantCulture = value; }
        public double NumeroDeParcelle { get => numeroParcelle; set => numeroParcelle = value; }
        public int CodeDeProduction { get => codeProduction; set => codeProduction = value; }
        public double Coordonnées{ get => coordonnées; set => coordonnées = value; }
        public DateTime DateDeDebut { get => dateDebut; set => dateDebut = value; }
        public DateTime DateDeFin { get => dateFin; set => dateFin = value; }
        public decimal QuantiteRecoltee { get => quantiteRecoltee; set => quantiteRecoltee = value; }


        public static List<Culture> CultureReader()
        {
            Db db = Db.GetDataBase();
            string query = "SELECT * FROM Culture";
            List<Culture> result = new List<Culture>();
            try
            {
                db.Connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, db.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Culture
                    {
                        NumeroIdentifiantCulture = reader.GetInt32("identifiant_culture"),
                        DateDeDebut = reader.GetDateTime("date_debut"),
                        DateDeFin = reader.GetDateTime("date_fin"),
                        QuantiteRecoltee = reader.GetDecimal("qt_recolte"),
                        NumeroDeParcelle = reader.GetInt16("no_parcelle"),
                        CodeDeProduction = reader.GetInt16("code_production"),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Source + " : " + ex.Message);
            }
            finally
            {
                db.Connection.Close();
            }
            return result;
        }
        #endregion
    }
}
