using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class Commercial
    {


        //Développer une fonction qui permet de créer un produit en fonction
        //de son nom.Le produit doit avoir le type de classe enfant qui
        //correspond à son nom.Par exemple, une classe « eau pétillante » doit
        //être de type « Boisson ».
        public Produit CreationProduitParNom(string nom)
        {
            switch (nom.ToLower())
            {
                case "coca":
                    return new Boisson("Coca", 0.2m, 2, 3);
                case "biere":
                    return new BoissonAlcoolisee("Biere", 0.5m, 4, 6,5.5m);
                case "chips":
                    return new Nourriture("Chips", 0.10m, 1, 2);
                case "mars":
                    return new Nourriture("Mars", 0.10m, 1.5m, 2);                
                case "gateau":
                    return new Nourriture("Gateau", 0.15m, 2m, 3);
                case "salade":
                    return new Nourriture("Salade", 0.5m, 1m, 1.5m);                
                case "sandwich":
                    return new Nourriture("Sandwich", 0.7m, 1.5m, 2m);
                case "sandwich ":
                    return new Nourriture("Sandwich vegetarien", 0.5m, 1.5m, 2m);
                default:
                    return null;
            }
        }

        //IV.3 Créer une fonction qui permet de passer commande de plusieurs
        //produits, en passant le nom du produit et un integer qui représente la
        //quantité à commander.
        public bool PasserCommande(string nom,int quantite,Stock stock)
        {
            if (quantite <= 0)
            {
                return false;
            }
            Produit produitDansStock = stock.TrouverProduit(nom);
            if(produitDansStock != null)
            {
                stock.AjouterStock(produitDansStock, quantite);
                return true;
            }
            else
            {
                Produit produitNouveau = this.CreationProduitParNom(nom);
                if(produitNouveau != null)
                {
                    stock.AjouterStock(produitNouveau, quantite);
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }

    }
}
