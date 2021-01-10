using NSubstitute;
using System;
using System.Collections.Generic;
using TP9;
using TP9Test.Builders;
using Xunit;

namespace TP9Test
{
    public class VenteProduits
    {
        Bde bdeTestBuilder = new BdeTestBuilder().BdeBuilder();
        ClientTestBuilder clientBuilderTest = new ClientTestBuilder();
        Produit produit = new ProduitTestBuilder().Builder();
        Produit jambon = new ProduitTestBuilder().JambonBuilder();
        Produit coca = new ProduitTestBuilder().CocaBuilder();


        [Fact]
        public void TestVenteProduitAvecMembre()
        {
            Client client = bdeTestBuilder.TrouverClientBde(new ClientTestBuilder().BuildEtudiants()[0]);
            bdeTestBuilder.StockBde.ChangerStockProduit("Coca", -1);
            bdeTestBuilder.ClientsBde[client] -= bdeTestBuilder.StockBde.TrouverProduit("Coca").PrixVenteMembre;

            Assert.Equal(0, bdeTestBuilder.StockBde.TrouverStockProduit("Coca"));
            Assert.Equal(99, bdeTestBuilder.ClientsBde[client]);
        }

        [Fact]
        public void TestTransaction()
        {
            List<Client> listeAutreClient = clientBuilderTest.BuildAutreClient();
            Transaction transaction = new Transaction(listeAutreClient[0], produit, produit.PrixVenteNonMembre);
            Assert.NotNull(transaction);
            Assert.Equal(2, transaction.PrixTransaction);
        }

        [Fact]
        public void TestVendre()
        {
            IVisitor concreteVisitorTransaction = Substitute.For<IVisitor>();
            List<Client> listeAutreClient = clientBuilderTest.BuildAutreClient();
            Transaction transaction = new Transaction(listeAutreClient[0], produit, produit.PrixVenteNonMembre);
            transaction.Accepter(concreteVisitorTransaction);
            concreteVisitorTransaction.Received().VisitTransaction(transaction);
        }

        [Fact]
        public void TestVisitTransactionClientAchat()
        {
            ConcreteVisitorClientAchat concreteVisitorClientAchat = new ConcreteVisitorClientAchat();
            List<Client> listeAutreClient = clientBuilderTest.BuildAutreClient();
            concreteVisitorClientAchat.VisitTransaction(new Transaction(listeAutreClient[0], produit, produit.PrixVenteNonMembre));
            concreteVisitorClientAchat.VisitTransaction(new Transaction(listeAutreClient[1], jambon, jambon.PrixVenteNonMembre));
            Assert.Equal("Client: CASTEX Jean, Value: 100" + Environment.NewLine
                + "Client: PHILLIPE Edouard, Value: 4" + Environment.NewLine, concreteVisitorClientAchat.VisitTransaction(new Transaction(listeAutreClient[0], coca, coca.PrixVenteNonMembre)));
        }

        [Fact]
        public void TestVisitTransaction()
        {
            ConcreteVisitorProduit concreteVisitorProduit = new ConcreteVisitorProduit();
            List<Client> listeAutreClient = clientBuilderTest.BuildAutreClient();
            Transaction transaction = new Transaction(listeAutreClient[0], produit, produit.PrixVenteNonMembre);
            Assert.Equal("Produit: Chips, Turnover: 2", concreteVisitorProduit.VisitTransaction(transaction));
        }
    }
}
