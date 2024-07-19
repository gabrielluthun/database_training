using MySql.Data.MySqlClient;
static void consoleConnexion()
{
    MySqlConnection connexionBDD = new MySqlConnection("server=localhost;user id=root;database= mcd_and_mld_into_bdd_exercice;password=");

    try
    {
        connexionBDD.Open();
        Console.WriteLine("Connexion à la base de données réussie");

    //Récupérer la valeur de id_culture dans la table culture
        MySqlCommand cmd2 = connexionBDD.CreateCommand();
        cmd2.CommandText = "SELECT id_culture FROM culture";
        MySqlDataReader reader = cmd2.ExecuteReader();  
        
        //Afficher la valeur de id_culture
        while (reader.Read())
        {
            Console.WriteLine(reader["id_culture"]);
        }
       
    } catch (Exception ex)
    {
        Console.WriteLine("Erreur de connexion à la base de données : " + ex.Message);
        throw;
    }
};

consoleConnexion();

