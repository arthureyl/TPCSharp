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
        PreparateurFormuleVegetarienne preparateurFormuleVegetarienne = new PreparateurFormuleVegetarienne();

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
        public void TestFakeFormulePreparationFormuleBiereSandwichDessertFake()
        {
            IStock fakeStock = new FakeStock();
            FormuleRepas formuleRepas = preparateurFormule.PreparationFormuleBiereSandwichDessert(fakeStock);
            Assert.NotNull(formuleRepas);
        }

        [Fact]
        public void TestFakeFormulePreparationFormuleDessertSodaFake()
        {
            IStock fakeStock = new FakeStock();
            FormuleRepas formuleRepas = preparateurFormule.PreparationFormuleDessertSoda(fakeStock);
            Assert.NotNull(formuleRepas);
        }

        [Fact]
        public void TestFakeFormuleTestPreparationFormuleBiereSandwichFake()
        {
            IStock fakeStock = new FakeStock();
            FormuleRepas formuleRepas = preparateurFormule.PreparationFormuleBiereSandwich(fakeStock);
            Assert.NotNull(formuleRepas);
        }

        [Fact]
        public void TestMockModificationStockAjouterBoisson()
        {
            IStock mockStock = Substitute.For<IStock>();
            preparateurFormule.AjouterBoisson(new Boisson("FakeProduit", 10, 10, 10), mockStock);
            mockStock.Received().ChangerStockProduit("FakeProduit", -1);
        }

        [Fact]
        public void TestMockModificationStockAjouterDessert()
        {
            IStock mockStock = Substitute.For<IStock>();
            preparateurFormule.AjouterDessert(new Nourriture("FakeProduit", 10, 10, 10), mockStock);
            mockStock.Received().ChangerStockProduit("FakeProduit", -1);
        }


        [Fact]
        public void TestMockModificationStockAjouterPlatPrincipal()
        {
            IStock mockStock = Substitute.For<IStock>();
            preparateurFormule.AjouterPlatPrincipal(new Nourriture("FakeProduit", 10, 10, 10), mockStock);
            mockStock.Received().ChangerStockProduit("FakeProduit", -1);
        }

        [Fact]
        public void TestPreparationFormuleDessertSodaVegetarien()
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
        public void TestPreparationFormuleBiereSandwichDessertVegetarien()
        {
            FormuleRepas formuleRepas = preparateurFormuleVegetarienne.PreparationFormuleBiereSandwichDessert(stock);
            Assert.Equal(3, formuleRepas.Formule.Count);
            Assert.Contains("Biere", formuleRepas.ToString());
            Assert.Contains("Sandwich vege", formuleRepas.ToString());
            Assert.Contains("Gateau", formuleRepas.ToString());
        }

        [Fact]
        public void TestMockModificationStockAjouterBoissonVegetarien()
        {
            IStock mockStock = Substitute.For<IStock>();
            preparateurFormuleVegetarienne.AjouterBoisson(new Boisson("FakeProduit", 10, 10, 10), mockStock);
            mockStock.Received().ChangerStockProduit("FakeProduit", -1);
        }

        [Fact]
        public void TestMockModificationStockAjouterDessertVegetarien()
        {
            IStock mockStock = Substitute.For<IStock>();
            preparateurFormuleVegetarienne.AjouterDessert(new Nourriture("FakeProduit", 10, 10, 10), mockStock);
            mockStock.Received().ChangerStockProduit("FakeProduit", -1);
        }


        [Fact]
        public void TestMockModificationStockAjouterPlatPrincipalVegetarien()
        {
            IStock mockStock = Substitute.For<IStock>();
            preparateurFormuleVegetarienne.AjouterPlatPrincipal(new Nourriture("FakeProduit", 10, 10, 10), mockStock);
            mockStock.Received().ChangerStockProduit("FakeProduit", -1);
        }
    }

    internal class FakeStock : IStock
    {
        public void AjouterStock(Produit produit, int quantite)
        {
        }

        public bool ChangerStockProduit(string nomProduit, int quantite)
        {
            return true;
        }

        public Produit TrouverProduit(string nomProduit)
        {
            return new Boisson("FakeProduit",10,10,10);
        }

        public int TrouverStockProduit(string nomProduit)
        {
            return 0;
        }
    }
}
