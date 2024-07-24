using GestionAgricole;
using GestionAgricole.App.Database;
using MySql.Data.MySqlClient;
using System.Net;
using System.Text;
using System.Text.Json;
// HttpListener : classe .NET permettant de communiquer via les protocoles HTTP

#region Création du serveur
HttpListener listener = new HttpListener();
listener.Prefixes.Add("http://localhost:8080/");
listener.Start();
Console.WriteLine("Serveur démarré sur http://localhost:8080/");
#endregion

#region Méthodes de gestion des requêtes
// Boucle infinie pour écouter les requêtes
while (true)
{
    //Contexte : objet qui contient toutes les informations sur la requête (réponse, requête)
    HttpListenerContext context = listener.GetContext();
    ThreadPool.QueueUserWorkItem(objet => RequestHandler(context));

}


//Fonction statique pour récupérer une requête
static void RequestHandler(HttpListenerContext context)
{
    HttpListenerRequest request = context.Request;
    Console.WriteLine($"Requête reçue :  {request.Url} ");

    //Récupérer les données de la base de données
    Db database = Db.GetDataBase();

    //Sérialiser le Db.Query en JSON
    object o = new {
        Cultures = Culture.CultureReader(),
        Parcelles = Parcelle.ParcelleReader()
    };
    string jsonResponse = JsonSerializer.Serialize(o);
    byte[] responsesBytes = Encoding.UTF8.GetBytes(jsonResponse);
    context.Response.ContentType = "application/json";
    context.Response.OutputStream.Write(responsesBytes, 0, responsesBytes.Length);
    context.Response.OutputStream.Close();
}
#endregion
