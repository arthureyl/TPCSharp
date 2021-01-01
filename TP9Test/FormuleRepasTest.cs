using System;
using System.Collections.Generic;
using System.Text;
using TP9;
using TP9Test.Builders;
using Xunit;

namespace TP9Test
{
    public class FormuleRepasTest
    {
        Produit cocaBoisson = new ProduitTestBuilder().CocaBuilder();
        Produit chipsNourriture = new ProduitTestBuilder().ChipsBuilder();
        FormuleRepas formuleRepas = new FormuleRepasTestBuilder().FormuleRepasBuilder();

        [Fact]
        public void TestAjouterProduit()
        {
            Assert.Equal(3, formuleRepas.Formule.Count);
        }
        [Fact]
        public void TestAfficherFormule()
        {
            Assert.Contains("Coca", formuleRepas.ToString());
            Assert.Contains("Chips", formuleRepas.ToString());
        }
        [Fact]
        public void TestPrixMenuMembre()
        {
            Assert.Equal(4.5m, formuleRepas.PrixFormuleMembre());
        }
        [Fact]
        public void TestPrixMenuNonMembre()
        {
            Assert.Equal(7.5m, formuleRepas.PrixFormuleNomMembre());
        }
    }
}
