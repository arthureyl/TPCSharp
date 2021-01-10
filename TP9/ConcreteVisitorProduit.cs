

using System.Collections.Generic;
using System.Linq;

namespace TP9
{
    public class ConcreteVisitorProduit : IVisitor
    {
        private Dictionary<Produit, decimal> _produitsVente;
        public Dictionary<Produit, decimal> ProduitsAchat { get => _produitsVente; set => _produitsVente = value; }
        public ConcreteVisitorProduit()
        {
            _produitsVente = new Dictionary<Produit, decimal>();
        }
        public string VisitTransaction(Transaction transaction)
        {
            if (ProduitsAchat.ContainsKey(transaction.VendableTransaction))
            {
                ProduitsAchat[transaction.VendableTransaction] += transaction.PrixTransaction;
            }
            else
            {
                ProduitsAchat.Add(transaction.VendableTransaction, transaction.PrixTransaction);
            }

            foreach (KeyValuePair<Produit, decimal> produit in ProduitsAchat.OrderByDescending(key => key.Value))
            {
                return "Produit: " + produit.Key.Nom + ", Turnover: " + produit.Value.ToString();
            }
            return "";
        }

    }

    
}
