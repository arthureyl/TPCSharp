namespace TP9
{
    public interface IObserver
    {
        // Receive update from subject
        void Update(Produit produit, int valeurStock, Stock stock);
    }
}
