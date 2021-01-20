﻿using System;
using System.Collections.Generic;

namespace TP9
{
    public class Bde : IObserver
    {

        //V.1 Créez la classe BDE, qui est composée d’une instance de la classe
        //stock ainsi que d’une collection de clients qui seront les clients qui
        //bénéficieront d’un tarif préférentiel.
        private Stock _stockBde;
        private Dictionary<Client, decimal> _clientsBde;
        private List<Transaction> _transactions;

        //Singleton 
        private static Bde _instance;
        private static readonly object _lock = new object();

        private ConcreteVisitorClientAchat _concreteVisitorClientAchat;
        private ConcreteVisitorProduit _concreteVisitorProduit;

        private Stack<BdeMomentoClients> _mementosClients;
        private Stack<BdeMomentoStock> _mementosStock;
        private Stack<BdeMomentoTransactions> _mementosTransactions;

        public Bde()
        {
            _stockBde = new Stock();
            _clientsBde = new Dictionary<Client, decimal>();
            _transactions = new List<Transaction>();
            _concreteVisitorClientAchat = new ConcreteVisitorClientAchat();
            _concreteVisitorProduit = new ConcreteVisitorProduit();
            _mementosClients = new Stack<BdeMomentoClients>();
            _mementosStock = new Stack<BdeMomentoStock>();
            _mementosTransactions = new Stack<BdeMomentoTransactions>();
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

        public Stock StockBde { get => _stockBde; set => _stockBde = value; }
        public Dictionary<Client, decimal> ClientsBde { get => _clientsBde; set => _clientsBde = value; }
        public List<Transaction> TransactionBde { get => _transactions; set => _transactions = value; }

        public Stack<BdeMomentoClients> MementosClients { get => _mementosClients; set => _mementosClients = value; }
        public Stack<BdeMomentoStock> MementosStock { get => _mementosStock; set => _mementosStock = value; }
        public Stack<BdeMomentoTransactions> MementosTransactions { get => _mementosTransactions; set => _mementosTransactions = value; }

        //V.2 Créez une méthode permettant d’ajouter des clients.Chaque client
        //aura un solde, de la même manière que le Stock a une quantité de
        //produits.
        public void AjouterClient(Client client, decimal solde)
        {
            BackupBdeMomentoClients();
            ClientsBde.Add(client, solde);
        }

        //V.3 Créez une méthode permettant de retourner tous les utilisateurs qui
        //ont un solde négatif, ou inférieur à une valeur passée en paramètre.
        //Pour ceci, vous utiliserez la possibilité de donner une valeur par
        //défaut à un argument passé en paramètre d’une méthode.
        public List<Client> TrouverUtilisateurSoldeNegatif(decimal solde = 0)
        {
            List<Client> listClients = new List<Client>();
            foreach (KeyValuePair<Client, decimal> client in ClientsBde)
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

        public void Update(Produit produit, int valeurStock, Stock stock)
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
        public void Vendre(Client client, Produit produit)
        {
            BackupBdeMomentoStock();
            this.StockBde.AjouterStock(produit, -1);
            Transaction transaction = null;
            BackupBdeMomentoTransactions();
            if (client is AutreClient)
            {
                transaction = new Transaction(client, produit, produit.PrixVenteNonMembre);
                TransactionBde.Add(transaction);
            }
            else
            {
                transaction = new Transaction(client, produit, produit.PrixVenteMembre);
                TransactionBde.Add(transaction);
            }
            transaction.Accepter(_concreteVisitorClientAchat);
            transaction.Accepter(_concreteVisitorProduit);
        }

        public BdeMomentoClients SauvegarderClients()
        {
            return new BdeMomentoClients(ClientsBde);
        }

        public BdeMomentoStock SauvegarderStock()
        {
            return new BdeMomentoStock(StockBde);
        }

        public BdeMomentoTransactions SauvegarderTransactions()
        {
            return new BdeMomentoTransactions(TransactionBde);
        }


        public void BackupBdeMomentoClients()
        {
            Console.WriteLine("\nCaretaker: Saving Originator's state...");
            this._mementosClients.Push(SauvegarderClients());
        }
        public void BackupBdeMomentoStock()
        {
            Console.WriteLine("\nCaretaker: Saving Originator's state...");
            this._mementosStock.Push(SauvegarderStock());
        }
        public void BackupBdeMomentoTransactions()
        {
            Console.WriteLine("\nCaretaker: Saving Originator's state...");
            this._mementosTransactions.Push(SauvegarderTransactions());
        }

    }
}
