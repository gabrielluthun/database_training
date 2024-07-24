using GestionAgricole.App.Database;
using MySql.Data.MySqlClient;
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
        private int _numeroParcelle;
        private double _surface;
        private string _nomParcelle;
        private string _coordonnées;

        // Propriétés
        public int NumeroParcelle { get => _numeroParcelle; set => _numeroParcelle = value; }
        public double Surface { get => _surface; set => _surface = value; }
        public string NomParcelle { get => _nomParcelle; set => _nomParcelle = value; }
        public string Coordonnées { get => _coordonnées; set => _coordonnées = value; }
     
        public static List<Parcelle> ParcelleReader()
        {
            Db db = Db.GetDataBase();
            string query = "SELECT * FROM Parcelle";
            List<Parcelle> result = new List<Parcelle>();
            try
            {
                db.Connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, db.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Parcelle
                    {
                        NumeroParcelle = reader.GetInt32("no_parcelle"),
                        Surface = reader.GetDouble("surface"),
                        NomParcelle = reader.GetString("nom_parcelle"),
                        Coordonnées = reader.GetString("coordonnees"),
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
