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

        public void AjouterBoisson(Produit produit, IStock stock)
        {
            stock.ChangerStockProduit(produit.Nom, -1);
            FormuleRepasVegetarienne.AjouterProduit(produit);
        }

        public void AjouterDessert(Produit produit, IStock stock)
        {
            stock.ChangerStockProduit(produit.Nom, -1);
            FormuleRepasVegetarienne.AjouterProduit(produit);
        }

        public void AjouterPlatPrincipal(Produit produit, IStock stock)
        {
            stock.ChangerStockProduit(produit.Nom, -1);
            FormuleRepasVegetarienne.AjouterProduit(produit);
        }

        public FormuleRepas PreparationFormuleDessertSoda(IStock stock)
        {
            AjouterBoisson(stock.TrouverProduit("Coca"),stock);
            AjouterDessert(stock.TrouverProduit("Gateau"),stock);
            return FormuleRepasVegetarienne;
        }

        public FormuleRepas PreparationFormuleBiereSalade(IStock stock)
        {
            AjouterBoisson(stock.TrouverProduit("Biere"),stock);
            AjouterPlatPrincipal(stock.TrouverProduit("Salade"),stock);
            return FormuleRepasVegetarienne;
        }

        public FormuleRepas PreparationFormuleBiereSandwichDessert(IStock stock)
        {
            AjouterBoisson(stock.TrouverProduit("Biere"),stock);
            AjouterPlatPrincipal(stock.TrouverProduit("Sandwich vege"),stock);
            AjouterDessert(stock.TrouverProduit("Gateau"),stock);
            return FormuleRepasVegetarienne;
        }

    }
}
