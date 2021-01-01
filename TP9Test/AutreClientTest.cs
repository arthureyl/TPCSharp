using System;
using System.Collections.Generic;
using System.Text;
using TP9;
using TP9Test.Builders;
using Xunit;

namespace TP9Test
{
    public class AutreClientTest
    {
        ClientTestBuilder clientBuilderTest = new ClientTestBuilder();
        [Fact]
        public void TestAutreClientList()
        {
            List<Client> listeAutreClient = clientBuilderTest.BuildAutreClient();
            Assert.Equal("PHILLIPE Edouard", listeAutreClient[0].GetName());
            Assert.NotEqual("SARKO Nicolas", listeAutreClient[0].GetName());
            Assert.Equal("CASTEX Jean", listeAutreClient[1].GetName());
        }
    }
}
