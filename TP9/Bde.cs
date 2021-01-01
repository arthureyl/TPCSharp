using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class Bde : IObserver
    {

        //V.1 Créez la classe BDE, qui est composée d’une instance de la classe
        //stock ainsi que d’une collection de clients qui seront les clients qui
        //bénéficieront d’un tarif préférentiel.
        private Stock _stockBde;
        private Dictionary<Client,decimal> _clientsBde;

        //Singleton 
        private static Bde _instance;
        private static readonly object _lock = new object();

        public Bde()
        {
            _stockBde = new Stock();
            _clientsBde = new Dictionary<Client,decimal>();
        }

        public static Bde GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Bde();
                    }
                }
            }
            return _instance;
        }

        public Stock StockBde { get => _stockBde; set => _stockBde = value;  }
        public Dictionary<Client, decimal> ClientsBde { get => _clientsBde; set => _clientsBde = value; }


        //V.2 Créez une méthode permettant d’ajouter des clients.Chaque client
        //aura un solde, de la même manière que le Stock a une quantité de
        //produits.
        public void AjouterClient(Client client, decimal solde)
        {
            ClientsBde.Add(client, solde);
        }

        //V.3 Créez une méthode permettant de retourner tous les utilisateurs qui
        //ont un solde négatif, ou inférieur à une valeur passée en paramètre.
        //Pour ceci, vous utiliserez la possibilité de donner une valeur par
        //défaut à un argument passé en paramètre d’une méthode.
        public List<Client> TrouverUtilisateurSoldeNegatif(decimal solde = 0)
        {
            List<Client> listClients = new List<Client>();
            foreach(KeyValuePair<Client, decimal> client in ClientsBde)
            {
                if (client.Value < solde)
                {
                    listClients.Add(client.Key);
                }
            }
            return listClients;
        }

        //V.4 Créez une méthode capable d’afficher une liste d’utilisateurs, que
        //vous testerez au minimum avec la liste des élèves du BDE et avec une
        //liste renvoyée par la méthode précédente.
        public void AfficherClientBde()
        {
            foreach (KeyValuePair<Client, decimal> client in ClientsBde)
            {
                Console.WriteLine(client.Key.GetName());
            }
        }

        public Client TrouverClientBde(Client clientATrouver)
        {
            foreach (KeyValuePair<Client, decimal> client in ClientsBde)
            {

                if (client.Key.GetName().Equals(clientATrouver.GetName()))
                {
                    return client.Key;
                }
            }
            return null;
        }

        public void Update(Produit produit, int valeurStock,Stock stock)
        {
            if (valeurStock < 10)
            {
                Console.WriteLine(produit.Nom + " stock < 10");
                Console.WriteLine("Nouvelle commande en cours.");
                Commercial commercial = new Commercial();
                if (commercial.PasserCommande(produit.Nom, 100, stock))
                {
                    Console.WriteLine("Commande effectuee");
                }
                else
                {
                    Console.WriteLine("Impossible de passer la commande");
                }
            }
        }
    }
}
