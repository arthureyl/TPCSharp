using NSubstitute;
using System.Collections.Generic;
using TP9;
using TP9Test.Builders;
using Xunit;

namespace TP9Test
{
    public class BdeTest
    {
        Bde bdeBuilderTest = new BdeTestBuilder().BdeBuilder();
        PreparateurFormule preparateurFormule = new PreparateurFormule();

        [Fact]
        public void VerifierBdeCreation()
        {
            Assert.Equal(4, bdeBuilderTest.ClientsBde.Count);
        }

        [Fact]
        public void TestTrouverSoldeNegatif()
        {
            List<Client> clientSoldeNegatif = bdeBuilderTest.TrouverUtilisateurSoldeNegatif();

            Assert.Single(clientSoldeNegatif);
            Assert.IsType<AutreClient>(clientSoldeNegatif[0]);
            Assert.Equal(-100, bdeBuilderTest.ClientsBde[clientSoldeNegatif[0]]);
        }

        [Fact]
        public void TestTrouverSoldeAvecParametre()
        {
            List<Client> clientSoldeNegatif = bdeBuilderTest.TrouverUtilisateurSoldeNegatif(10);

            Assert.Equal(3, clientSoldeNegatif.Count);
            Assert.IsType<Etudiant>(clientSoldeNegatif[0]);
            Assert.IsType<AutreClient>(clientSoldeNegatif[1]);
            Assert.IsType<AutreClient>(clientSoldeNegatif[2]);
        }

        [Fact]
        public void TestAjouterClient()
        {
            Client clientEtudiant = new Etudiant("testnom", "testprenom", 2000);
            bdeBuilderTest.AjouterClient(clientEtudiant, 10);

            Assert.Equal(10, bdeBuilderTest.ClientsBde[clientEtudiant]);
            Assert.Equal(5, bdeBuilderTest.ClientsBde.Count);
        }

        [Fact]
        public void TestTrouverClient()
        {
            Client client = bdeBuilderTest.TrouverClientBde(new ClientTestBuilder().BuildEtudiants()[0]);
            Assert.Equal("TRUMP Donald", client.GetName());
        }

        [Fact]
        public void TestObserver()
        {
            bdeBuilderTest.StockBde.Attach(bdeBuilderTest);
            Assert.True(bdeBuilderTest.StockBde.ChangerStockProduit("Coca", -1));
            Assert.Equal(100, bdeBuilderTest.StockBde.TrouverStockProduit("Coca"));
        }

        [Fact]
        public void TestObserverPreparateurFormule()
        {
            bdeBuilderTest.StockBde.Attach(bdeBuilderTest);
            preparateurFormule.PreparationFormuleDessertSoda(bdeBuilderTest.StockBde);
            Assert.Equal(100, bdeBuilderTest.StockBde.TrouverStockProduit("Coca"));
        }

        [Fact]
        public void TestObserverUtilisationChangementStock()
        {
            IObserver mockObserver = Substitute.For<IObserver>();
            bdeBuilderTest.StockBde.Attach(mockObserver);
            bdeBuilderTest.StockBde.ChangerStockProduit("Coca", -1);
            mockObserver.Received().Update(bdeBuilderTest.StockBde.TrouverProduit("Coca"), 0, bdeBuilderTest.StockBde);
        }

        [Fact]
        public void TestObserverUtilisatioPreparationFormule()
        {
            IObserver mockObserver = Substitute.For<IObserver>();
            bdeBuilderTest.StockBde.Attach(mockObserver);
            preparateurFormule.PreparationFormuleDessertSoda(bdeBuilderTest.StockBde);
            mockObserver.Received().Update(bdeBuilderTest.StockBde.TrouverProduit("Coca"), 0, bdeBuilderTest.StockBde);
        }

        [Fact]
        public void TestDetachObserverUtilisatioPreparationFormule()
        {
            IObserver mockObserver = Substitute.For<IObserver>();
            bdeBuilderTest.StockBde.Attach(mockObserver);
            bdeBuilderTest.StockBde.Detach(mockObserver);
            preparateurFormule.PreparationFormuleDessertSoda(bdeBuilderTest.StockBde);
            mockObserver.DidNotReceive().Update(bdeBuilderTest.StockBde.TrouverProduit("Coca"), 0, bdeBuilderTest.StockBde);
        }

        [Fact]
        public void TestAjouterClientMomento()
        {

            bdeBuilderTest.AjouterClient(new Etudiant("testnom", "testprenom", 2000), 10);
            Assert.NotEqual(bdeBuilderTest.ClientsBde, bdeBuilderTest.MementosClients.Peek().Clients);
            Assert.Equal(bdeBuilderTest.ClientsBde.Count-1, bdeBuilderTest.MementosClients.Peek().Clients.Count);
            Bde newBdeBuilderTest = new BdeTestBuilder().BdeBuilder();
            Assert.NotEqual(newBdeBuilderTest.ClientsBde, bdeBuilderTest.MementosClients.Peek().Clients);

        }

        [Fact]
        public void TestVendreMomentoStock()
        {
            Client testEtudiant = new Etudiant("testnom", "testprenom", 2000);
            bdeBuilderTest.AjouterClient(testEtudiant, 1000);
            bdeBuilderTest.Vendre(testEtudiant, bdeBuilderTest.StockBde.TrouverProduit("Chips"));
            Assert.Equal(10, bdeBuilderTest.MementosStock.Peek().GetStock.TrouverStockProduit("Chips"));
        }

        [Fact]
        public void TestVendreMomentoTransaction()
        {
            Client testEtudiant = new Etudiant("testnom", "testprenom", 2000);
            List<Transaction> transactionsTestSave = new List<Transaction>(bdeBuilderTest.TransactionBde);
            bdeBuilderTest.AjouterClient(testEtudiant, 1000);
            bdeBuilderTest.Vendre(testEtudiant, bdeBuilderTest.StockBde.TrouverProduit("Chips"));
            Assert.Equal(transactionsTestSave, bdeBuilderTest.MementosTransactions.Peek().Transactions);
        }
    }
}
