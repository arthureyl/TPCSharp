using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using TP9;

namespace TP9Test.Builders
{
    public class ClientTestBuilder
    {
        List<Client> _listeClient;

        public ClientTestBuilder()
        {
            _listeClient = new List<Client>();
        }

        //VI.4 Utilisez un fichier au format de votre choix pour lire un fichier au
        //format texte, CSV, etc... (au choix) pour fournir des exemples
        //d’étudiants en fonction de votre promotion.
        public List<Client> BuildEtudiants()
        {
            string pathJsonClients = @"C:\Users\Shadow\source\repos\TP9Test\Builders\JsonEtudiants.json";
            List<Client> listeClient = new List<Client>();

            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(pathJsonClients);
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                dynamic data = JObject.Parse(line);
                int anneeDiplome = (int)data._anneeDiplome;
                string nom = data._nom;
                string prenom = data._prenom;
                Etudiant etudiant = new Etudiant(nom, prenom, anneeDiplome);
                listeClient.Add(etudiant);
            }

            file.Close();
            return listeClient;
        }

        public List<Client> BuildAutreClient()
        {
            string pathJsonClients = @"C:\Users\Shadow\source\repos\TP9Test\Builders\JsonAutresClients.json";
            List<Client> listeClient = new List<Client>();

            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(pathJsonClients);
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                dynamic data = JObject.Parse(line);
                string nom = data._nom;
                string prenom = data._prenom;
                AutreClient autreClient = new AutreClient(nom, prenom);
                listeClient.Add(autreClient);
            }

            file.Close();
            return listeClient;
        }

    }
}
