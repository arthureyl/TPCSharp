using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class PreparateurFormuleVegetarienne : IAssembleur
    {
        FormuleRepas _formuleRepasVegetarienne;
        public FormuleRepas FormuleRepasVegetarienne { get => _formuleRepasVegetarienne; set => _formuleRepasVegetarienne = value; }

        public PreparateurFormuleVegetarienne()
        {
            FormuleRepasVegetarienne = new FormuleRepas();
        }

        public void AjouterBoisson(Produit produit)
        {
            FormuleRepasVegetarienne.AjouterProduit(produit);
        }

        public void AjouterDessert(Produit produit)
        {
            FormuleRepasVegetarienne.AjouterProduit(produit);
        }

        public void AjouterPlatPrincipal(Produit produit)
        {
            FormuleRepasVegetarienne.AjouterProduit(produit);
        }

        public FormuleRepas PreparationFormuleDessertSoda(Stock stock)
        {
            Produit soda = stock.TrouverProduit("Coca");
            Produit dessert = stock.TrouverProduit("Gateau");
            stock.ChangerStockProduit(soda.Nom, -1);
            stock.ChangerStockProduit(dessert.Nom, -1);
            AjouterBoisson(soda);
            AjouterDessert(dessert);
            return FormuleRepasVegetarienne;
        }

        public FormuleRepas PreparationFormuleBiereSalade(Stock stock)
        {
            Produit biere = stock.TrouverProduit("Biere");
            Produit salade = stock.TrouverProduit("Salade");
            stock.ChangerStockProduit(biere.Nom, -1);
            stock.ChangerStockProduit(salade.Nom, -1);
            AjouterBoisson(biere);
            AjouterPlatPrincipal(salade);
            return FormuleRepasVegetarienne;
        }

        public FormuleRepas PreparationFormuleBiereSandwichDessert(Stock stock)
        {
            Produit biere = stock.TrouverProduit("Biere");
            Produit sandwich = stock.TrouverProduit("Sandwich vege");
            Produit dessert = stock.TrouverProduit("Gateau");
            stock.ChangerStockProduit(biere.Nom, -1);
            stock.ChangerStockProduit(sandwich.Nom, -1);
            stock.ChangerStockProduit(dessert.Nom, -1);
            AjouterBoisson(biere);
            AjouterPlatPrincipal(sandwich);
            AjouterDessert(dessert);
            return FormuleRepasVegetarienne;
        }

    }
}
