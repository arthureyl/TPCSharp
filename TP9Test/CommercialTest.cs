using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using TP9;
using TP9Test.Builders;
using Xunit;

namespace TP9Test
{
    public class CommercialTest
    {
        Commercial commercial = new Commercial();
        Stock stockProduit = new StockTestBuilder().StockBuilder();
        [Fact]
        public void TestCreationDeProduitParNom()
        {
            Produit produit = commercial.CreationProduitParNom("mars");
            Assert.NotNull(produit);
            Assert.Equal("Mars", produit.Nom);
        }

        [Fact]
        public void TestCreationDeProduitParNomInconnu()
        {
            Produit produit = commercial.CreationProduitParNom("bonbon");
            Assert.Null(produit);
        }

        [Fact]
        public void TestAjouterDansStockAvecProduitDansStock()
        {
            Assert.True(commercial.PasserCommande("Biere", 10, stockProduit));
            Assert.Equal(110, stockProduit.TrouverStockProduit("Biere"));
        }

        [Fact]
        public void TestAjouterDansStockSansProduitDansStock()
        {
            Assert.True(commercial.PasserCommande("Mars", 50, stockProduit));
            Assert.Equal(50, stockProduit.TrouverStockProduit("Mars"));
        }

        [Fact]
        public void TestAjouterStockNegatif()
        {
            Assert.False(commercial.PasserCommande("Mars", -50, stockProduit));
        }

        [Fact]
        public void TestAjouterDansStockAvecProduitInconnu()
        {
            Assert.False(commercial.PasserCommande("bonbon", 50, stockProduit));
        }

        [Fact]
        public void TestMockPasseCommande()
        {
            IStock mockStock = Substitute.For<IStock>();
            Assert.True(commercial.PasserCommande("Coca", 100, mockStock));
            mockStock.Received().AjouterStock(Arg.Any<Boisson>(), 100);
        }

        [Fact]
        public void TestMockPasseCommandeArticleInconnu()
        {
            IStock mockStock = Substitute.For<IStock>();
            Assert.False(commercial.PasserCommande("Inconnu", 100, mockStock));
            mockStock.DidNotReceive().AjouterStock(Arg.Any<Boisson>(), 100);
        }
    }
}
