namespace TP9
{
    public interface IAssembleur
    {
        public void AjouterPlatPrincipal(Produit produit, IStock stock);
        public void AjouterBoisson(Produit produit, IStock stock);
        public void AjouterDessert(Produit produit, IStock stock);
    }
}
