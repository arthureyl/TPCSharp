using System;
using System.Collections.Generic;
using System.Text;
using TP9;

namespace TP9Test.Builders
{
    public class FormuleRepasTestBuilder
    {
        FormuleRepas _formuleRepasTest;

        public FormuleRepas FormuleRepasTest { get; set; }

        public FormuleRepasTestBuilder()
        {
            FormuleRepasTest = new FormuleRepas();
        }

        public FormuleRepas FormuleRepasBuilder()
        {
            ProduitTestBuilder produitBuilder = new ProduitTestBuilder(); ;
            FormuleRepasTest.AjouterProduit(produitBuilder.ChipsBuilder());
            FormuleRepasTest.AjouterProduit(produitBuilder.BiereBuilder());
            FormuleRepasTest.AjouterProduit(produitBuilder.CocaBuilder());

            return FormuleRepasTest;
        }
    }
}
