using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using TP9;
using TP9Test.Builders;
using Xunit;

namespace TP9Test
{
    public class PreparateurFormuleTest
    {
        Stock stock = new StockTestBuilder().StockBuilder();
        PreparateurFormule preparateurFormule = new PreparateurFormule();

        [Fact]
        public void TestPreparationFormuleBiereSandwich()
        {
            FormuleRepas formuleRepas = preparateurFormule.PreparationFormuleBiereSandwich(stock);
            Assert.Equal(2, formuleRepas.Formule.Count);
            Assert.Contains("Biere",formuleRepas.ToString());
            Assert.Contains("Sandwich", formuleRepas.ToString());
        }

        [Fact]
        public void TestPreparationFormuleBiereSandwichDessert()
        {
            FormuleRepas formuleRepas = preparateurFormule.PreparationFormuleBiereSandwichDessert(stock);
            Assert.Equal(3, formuleRepas.Formule.Count);
            Assert.Contains("Biere", formuleRepas.ToString());
            Assert.Contains("Sandwich", formuleRepas.ToString());
            Assert.Contains("Tiramisu", formuleRepas.ToString());
        }

        [Fact]
        public void TestPreparationFormuleDessertSoda()
        {
            FormuleRepas formuleRepas = preparateurFormule.PreparationFormuleDessertSoda(stock);
            Assert.Equal(2, formuleRepas.Formule.Count);
            Assert.Contains("Coca", formuleRepas.ToString());
            Assert.Contains("Tiramisu", formuleRepas.ToString());
        }

        [Fact]
        public void TestFormuleRepasAjouterProduit()
        {
            FormuleRepas mockFormuleRepas = Substitute.For<FormuleRepas>();
            PreparateurFormule preparateurFormuleTest = new PreparateurFormule(mockFormuleRepas);
            preparateurFormule.PreparationFormuleDessertSoda(stock);
            mockFormuleRepas.Received().AjouterProduit(stock.TrouverProduit("Coca"));
            mockFormuleRepas.Received().AjouterProduit(stock.TrouverProduit("Tiramisu"));
            mockFormuleRepas.DidNotReceive().AjouterProduit(stock.TrouverProduit("Biere"));
        }

        [Fact]
        public void TestFormuleRepasChangerStockProduit()
        {
            Stock mockStock = Substitute.For<Stock>();
            ProduitTestBuilder produitBuilder = new ProduitTestBuilder();
            mockStock.AjouterStock(produitBuilder.CocaBuilder(), 10);
            mockStock.AjouterStock(produitBuilder.TiramisuBuilder(), 100);
            preparateurFormule.PreparationFormuleDessertSoda(mockStock);
            mockStock.Received().ChangerStockProduit("Coca",-1);
        }

    }
}
