using System;
using System.Collections.Generic;
using System.Text;
using TP9;
using TP9Test.Builders;
using Xunit;

namespace TP9Test
{
    public class TestPreparateurFormuleVegetarienne
    {
        PreparateurFormuleVegetarienne preparateurFormuleVegetarienne = new PreparateurFormuleVegetarienne();
        Stock stock = new StockTestBuilder().StockBuilder();

        [Fact]
        public void TestPreparationFormuleDessertSoda()
        {
            FormuleRepas formuleRepas = preparateurFormuleVegetarienne.PreparationFormuleDessertSoda(stock);
            Assert.Equal(2, formuleRepas.Formule.Count);
            Assert.Contains("Coca", formuleRepas.ToString());
            Assert.Contains("Gateau", formuleRepas.ToString());
        }

        [Fact]
        public void TestPreparationFormuleBiereSalade()
        {
            FormuleRepas formuleRepas = preparateurFormuleVegetarienne.PreparationFormuleBiereSalade(stock);
            Assert.Equal(2, formuleRepas.Formule.Count);
            Assert.Contains("Biere", formuleRepas.ToString());
            Assert.Contains("Salade", formuleRepas.ToString());
        }

        [Fact]
        public void TestPreparationFormuleBiereSandwichDessert()
        {
            FormuleRepas formuleRepas = preparateurFormuleVegetarienne.PreparationFormuleBiereSandwichDessert(stock);
            Assert.Equal(3, formuleRepas.Formule.Count);
            Assert.Contains("Biere", formuleRepas.ToString());
            Assert.Contains("Sandwich vege", formuleRepas.ToString());
            Assert.Contains("Gateau", formuleRepas.ToString());
        }
    }
}
