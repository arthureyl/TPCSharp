using TP9;
using TP9Test.Builders;
using Xunit;

namespace TP9Test
{
    public class StockTest
    {
        Stock stockProduit = new StockTestBuilder().StockBuilder();
        PreparateurFormule preparateurFormule = new PreparateurFormule();
        ProduitTestBuilder produitBuilder = new ProduitTestBuilder();

        [Fact]
        public void TestCreationStock()
        {
            Assert.NotNull(stockProduit);
            Assert.IsType<Stock>(stockProduit);
        }

        [Fact]
        public void TestTrouverProduit()
        {
            Assert.NotNull(stockProduit.TrouverProduit("Chips"));
            Assert.NotNull(stockProduit.TrouverProduit("Coca"));
            Assert.Null(stockProduit.TrouverProduit("Jambon"));
        }

        [Fact]
        public void TestTrouverStockProduit()
        {
            Assert.Equal(10, stockProduit.TrouverStockProduit("Chips"));
        }

        [Fact]
        public void TestAjouterProduitStock()
        {
            stockProduit.AjouterStock(new ProduitTestBuilder().JambonBuilder(), 150);
            Assert.Equal(150, stockProduit.TrouverStockProduit("Jambon"));
        }

        [Fact]
        public void TestChangerStockProduit()
        {
            Assert.False(stockProduit.ChangerStockProduit("Coca", -10));
            Assert.True(stockProduit.ChangerStockProduit("Coca", -1));
            Assert.True(stockProduit.ChangerStockProduit("Coca", 10));
            Assert.True(stockProduit.ChangerStockProduit("Coca", -8));
        }
    }
}
