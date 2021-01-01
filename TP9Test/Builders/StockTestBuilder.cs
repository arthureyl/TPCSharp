using System;
using System.Collections.Generic;
using System.Text;
using TP9;

namespace TP9Test.Builders
{
    public class StockTestBuilder
    {
        Stock _stockProduit;

        public Stock StockProduit { get; set; }

        public StockTestBuilder()
        {
            StockProduit = new Stock();
        }

        public Stock StockBuilder()
        {
            ProduitTestBuilder produitBuilder = new ProduitTestBuilder(); ;
            StockProduit.AjouterStock(produitBuilder.ChipsBuilder(), 10);
            StockProduit.AjouterStock(produitBuilder.BiereBuilder(), 100);
            StockProduit.AjouterStock(produitBuilder.CocaBuilder(), 1);
            StockProduit.AjouterStock(produitBuilder.SandwichBuilder(), 75);
            StockProduit.AjouterStock(produitBuilder.TiramisuBuilder(), 100);
            StockProduit.AjouterStock(produitBuilder.GateauBuilder(), 100);
            StockProduit.AjouterStock(produitBuilder.SaladeBuilder(), 100);
            StockProduit.AjouterStock(produitBuilder.SandwichVegetarienBuilder(), 100);

            return StockProduit;
        }
    }
}
