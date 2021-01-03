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

        public void AjouterBoisson(Produit produit,IStock stock)
        {   
                stock.ChangerStockProduit(produit.Nom, -1);
                FormuleRepasNormal.AjouterProduit(produit);
        }

        public void AjouterDessert(Produit produit, IStock stock)
        {
            stock.ChangerStockProduit(produit.Nom, -1);
            FormuleRepasNormal.AjouterProduit(produit);
        }

        public void AjouterPlatPrincipal(Produit produit, IStock stock)
        {
            stock.ChangerStockProduit(produit.Nom, -1);
            FormuleRepasNormal.AjouterProduit(produit);
        }

        public FormuleRepas PreparationFormuleDessertSoda(IStock stock)
        {
            AjouterBoisson(stock.TrouverProduit("Coca"), stock);
            AjouterDessert(stock.TrouverProduit("Tiramisu"), stock);
            return FormuleRepasNormal;
        }

        public FormuleRepas PreparationFormuleBiereSandwich(IStock stock)
        {
            AjouterBoisson(stock.TrouverProduit("Biere"),stock);
            AjouterPlatPrincipal(stock.TrouverProduit("Sandwich"),stock);
            return FormuleRepasNormal;
        }

        public FormuleRepas PreparationFormuleBiereSandwichDessert(IStock stock)
        {
            AjouterBoisson(stock.TrouverProduit("Biere"),stock);
            AjouterPlatPrincipal(stock.TrouverProduit("Sandwich"), stock);
            AjouterDessert(stock.TrouverProduit("Tiramisu"), stock);
            return FormuleRepasNormal;
        }

    }
}
