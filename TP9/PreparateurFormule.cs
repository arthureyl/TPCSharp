using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class PreparateurFormule : IAssembleur
    {
        FormuleRepas _formuleRepasNormal;
        public FormuleRepas FormuleRepasNormal { get => _formuleRepasNormal; set => _formuleRepasNormal = value; }

        public PreparateurFormule()
        {
            FormuleRepasNormal = new FormuleRepas();
        }
        public void AjouterBoisson(Produit produit)
        {
            FormuleRepasNormal.AjouterProduit(produit);
        }

        public void AjouterDessert(Produit produit)
        {
            FormuleRepasNormal.AjouterProduit(produit);
        }

        public void AjouterPlatPrincipal(Produit produit)
        {
            FormuleRepasNormal.AjouterProduit(produit);
        }

        public FormuleRepas PreparationFormuleDessertSoda(Stock stock)
        {
            Produit soda = stock.TrouverProduit("Coca");
            Produit dessert = stock.TrouverProduit("Tiramisu");
            stock.ChangerStockProduit(soda.Nom, -1);
            stock.ChangerStockProduit(dessert.Nom, -1);
            AjouterBoisson(soda);
            AjouterDessert(dessert);
            return FormuleRepasNormal;
        }

        public FormuleRepas PreparationFormuleBiereSandwich(Stock stock)
        {
            Produit biere = stock.TrouverProduit("Biere");
            Produit sandwich = stock.TrouverProduit("Sandwich");
            stock.ChangerStockProduit(biere.Nom, -1);
            stock.ChangerStockProduit(sandwich.Nom, -1);
            AjouterBoisson(biere);
            AjouterPlatPrincipal(sandwich);
            return FormuleRepasNormal;
        }

        public FormuleRepas PreparationFormuleBiereSandwichDessert(Stock stock)
        {
            Produit biere = stock.TrouverProduit("Biere");
            Produit sandwich = stock.TrouverProduit("Sandwich");
            Produit dessert = stock.TrouverProduit("Tiramisu");
            stock.ChangerStockProduit(biere.Nom, -1);
            stock.ChangerStockProduit(sandwich.Nom, -1);
            stock.ChangerStockProduit(dessert.Nom, -1);
            AjouterBoisson(biere);
            AjouterPlatPrincipal(sandwich);
            AjouterDessert(dessert);
            return FormuleRepasNormal;
        }
    }
}
