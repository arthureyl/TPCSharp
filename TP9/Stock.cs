using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class Stock : IObservable
    {
        Dictionary<Produit, int> _stockProduit;
        private List<IObserver> _observers = new List<IObserver>();
        public Dictionary<Produit, int> StockProduit{ get => _stockProduit; set => _stockProduit = value; }

        public Stock()
        {
            _stockProduit = new Dictionary<Produit, int>();
        }

        //III.1Développer une fonction qui permet de récupérer un produit en
        //fonction de son nom. (Renvoie null s’il n’existe pas)
        public Produit TrouverProduit(string nomProduit)
        {
            foreach (KeyValuePair<Produit, int> produit in StockProduit)
            {
                if (produit.Key.Nom.Equals(nomProduit))
                {
                    return produit.Key;
                }
            }

            return null;
        }

        //III.2Développer une fonction qui permet de récupérer la quantité d’un
        //produit en fonction de son nom. (Renvoie 0 s’il n’existe pas)
        public int TrouverStockProduit(string nomProduit)
        {

            foreach (KeyValuePair<Produit, int> produit in StockProduit)
            {
                if (produit.Key.Nom.Equals(nomProduit))
                {
                    return produit.Value;
                }
            }

            return 0;
        }

        //III.3Créer une fonction permettant de faire varier le stock d’un certain
        //montant.Renvoie true si la transaction est possible, renvoie false
        //sinon(stock insuffisant ou produit introuvable).
        public bool ChangerStockProduit(string nomProduit, int quantite)
        {
            Produit produit = this.TrouverProduit(nomProduit);
            if (produit == null)
            {
                return false;
            }
            else
            {
                if ((StockProduit[produit] + quantite)>=0)
                {
                    StockProduit[produit] += quantite;
                    this.Notify(produit, StockProduit[produit]);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //III.4 Créer une méthode permettant d’ajouter des produits au stock(en
        //les achetant à un fournisseur)
        public void AjouterStock(Produit produit,int quantite)
        {
            if(StockProduit.ContainsKey(produit))
            {
                StockProduit[produit] += quantite;
            }
            else
            {
                StockProduit.Add(produit, quantite);
            }
        }

        //III.5Créer une méthode permettant d’afficher tout le stock dans la
        //console.
        public void AfficherStocks()
        {
            Console.WriteLine("AfficherStocks lancé : ");
            foreach (KeyValuePair<Produit, int> produit in StockProduit)
            {
                Console.WriteLine(produit.Key.Nom + " : " + produit.Value);
            }

        }
        // The subscription management methods.
        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        // Trigger an update in each subscriber.
        public void Notify(Produit produit, int quantite)
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(produit,quantite,this);
            }
        }
    }
}
