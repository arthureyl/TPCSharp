using TP9;
using TP9Test.Builders;
using Xunit;

namespace TP9Test
{
    public class ProduitTest
    {
        Produit produit = new ProduitTestBuilder().Builder();

        [Fact]
        public void TestCreationProduit()
        {
            Assert.NotNull(this.produit);
            Assert.IsType<Nourriture>(this.produit);
        }

        [Fact]
        public void TestAccessProduit()
        {
            Assert.Equal("Chips", this.produit.Nom);
            Assert.Equal(0.5m, this.produit.PrixAchat);
            Assert.Equal(1.5m, this.produit.PrixVenteMembre);
            Assert.Equal(2, this.produit.PrixVenteNonMembre);
            Assert.Equal("Sachet", this.produit.Emballage);
        }

        [Fact]
        public void TestEmballageBoisson()
        {
            Produit produitBoisson = new ProduitTestBuilder().CocaBuilder();
            Assert.Equal("Bouteille", produitBoisson.Emballage);
        }

        [Fact]
        public void TestCalculerPrixMembre()
        {
            Produit produitBoisson = new ProduitTestBuilder().CocaBuilder();
            Assert.Equal(1, produitBoisson.CalculerPrixMembre());
        }

        [Fact]
        public void TestCalculerPrixNonMembre()
        {
            Produit produitBoisson = new ProduitTestBuilder().CocaBuilder();
            Assert.Equal(2, produitBoisson.CalculerPrixNonMembre());
        }
    }
}
