using System;
using System.Collections.Generic;
using System.Text;
using TP9;

namespace TP9Test.Builders
{
    public class BdeTestBuilder
    {

        private Bde _bdeTest;

        public Bde BdeTest { get => _bdeTest; set => _bdeTest = value; }

        public BdeTestBuilder()
        {
            _bdeTest  = new Bde();
        }

        public Bde BdeBuilder()
        {
            List<Client> listeEtudiant = new ClientTestBuilder().BuildEtudiants();
            List<Client> listeAutreClient = new ClientTestBuilder().BuildAutreClient();

            BdeTest.AjouterClient(listeEtudiant[0], 100);
            BdeTest.AjouterClient(listeEtudiant[1], 0);

            BdeTest.AjouterClient(listeAutreClient[0], -100);
            BdeTest.AjouterClient(listeAutreClient[1], 5);

            BdeTest.StockBde = new StockTestBuilder().StockBuilder();

            return BdeTest;
        }
    }
}
