using System;
using System.Collections.Generic;
using System.Text;
using TP9;
using TP9Test.Builders;
using Xunit;

namespace TP9Test
{
    public class EtudiantTest
    {
        ClientTestBuilder clientBuilderTest = new ClientTestBuilder();
        [Fact]
        public void TestEtudiantCreation()
        {
            Etudiant etudiant = new Etudiant("Testnom", "Testprenom", 2020);
            Assert.NotNull(etudiant);
            Assert.IsType<Etudiant>(etudiant);
            Assert.NotEqual("Testnom", etudiant.Nom);
            Assert.Equal("TESTNOM Testprenom", etudiant.GetName());
        }

        [Fact]
        public void TestEtudiantList()
        {
            List<Client> listeEtudiant = clientBuilderTest.BuildEtudiants();
            Assert.Equal("TRUMP Donald", listeEtudiant[0].GetName());
            Assert.NotEqual("SARKO Nicolas", listeEtudiant[0].GetName());
            Assert.Equal("SARKO Nicolas", listeEtudiant[1].GetName());
        }
    }
}
