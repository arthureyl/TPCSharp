namespace TP9
{
    public class Transaction : ITransaction
    {
        private Client _client;
        private Produit _produit;
        private decimal _prix;

        public Client ClientTransaction { get => _client; set => _client = value; }
        public Produit VendableTransaction { get => _produit; set => _produit = value; }
        public decimal PrixTransaction { get => _prix; set => _prix = value; }

        public Transaction(Client client, Produit produit, decimal prix)
        {
            ClientTransaction = client;
            VendableTransaction = produit;
            PrixTransaction = prix;
        }

        public void Accepter(IVisitor visitor)
        {
            visitor.VisitTransaction(this);
        }
    }
}
