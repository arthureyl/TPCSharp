using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public interface IStock
    {
        public Produit TrouverProduit(string nomProduit);
        public int TrouverStockProduit(string nomProduit);
        public bool ChangerStockProduit(string nomProduit, int quantite);
        public void AjouterStock(Produit produit, int quantite);

    }
}
