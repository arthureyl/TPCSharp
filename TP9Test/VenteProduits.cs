using System;
using System.Collections.Generic;
using System.Text;
using TP9;
using TP9Test.Builders;
using Xunit;

namespace TP9Test
{
    public class VenteProduits
    {
        Bde bdeTestBuilder = new BdeTestBuilder().BdeBuilder();

        [Fact]
        public void TestVenteProduitAvecMembre()
        {
            Client client = bdeTestBuilder.TrouverClientBde(new ClientTestBuilder().BuildEtudiants()[0]);
            bdeTestBuilder.StockBde.ChangerStockProduit("Coca", -1);
            bdeTestBuilder.ClientsBde[client] -= bdeTestBuilder.StockBde.TrouverProduit("Coca").PrixVenteMembre;

            Assert.Equal(0, bdeTestBuilder.StockBde.TrouverStockProduit("Coca"));
            Assert.Equal(99, bdeTestBuilder.ClientsBde[client]);
        }
    }
}
