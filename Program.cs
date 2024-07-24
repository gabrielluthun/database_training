using GestionAgricole;
using GestionAgricole.App.Database;
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
    Console.WriteLine($"Requête reçue :  {request.Url} Route : {request.Url.AbsolutePath}");

    //Initialisation de la réponse par défaut
   var data = new { message = "Endpoint non trouvé" };

    //Vérifier l'URL pour déterminer l'endpoint
    switch (request.Url.AbsolutePath)
    {
        case "/culture":
            //Afficher les données de la BDD de la table "culture"
            List<Culture> cultures = Culture.CultureReader();
            string cultureJson = JsonSerializer.Serialize(cultures);
            data = new { message = cultureJson };
            break;
        case "/parcelle":
            List<Parcelle> parcelles = Parcelle.ParcelleReader();
            string parcelleJson = JsonSerializer.Serialize(parcelles);
            data = new { message = parcelleJson };
            break;
        case "/engrais":
            List<Engrais> engrais = Engrais.EngraisReader();
            string engraisJson = JsonSerializer.Serialize(engrais);
            data = new { message = engraisJson };
            break;
        case "/unités":
            data = new { message = "Je poucave pas ma réponse" };
            break;
    }



    string jsonData = JsonSerializer.Serialize(data);
    byte[] responseBytes = Encoding.UTF8.GetBytes(jsonData);


    //Récupérer les données de la base de données
    Db database = Db.GetDataBase();

    //Sérialiser les BDD en JSON
    object o = new {
        Cultures = Culture.CultureReader(),
        Parcelles = Parcelle.ParcelleReader(),
        Engrais = Engrais.EngraisReader(),
        Unités = Unité.UniteReader(),
        ElementChimiques = ElementChimiques.ECReader()
    };
    //string jsonResponse = JsonSerializer.Serialize(o);
    byte[] responsesBytes = Encoding.UTF8.GetBytes(jsonData);
    context.Response.ContentType = "application/json";
    context.Response.OutputStream.Write(responsesBytes, 0, responsesBytes.Length);
    context.Response.OutputStream.Close();
}
#endregion
