using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public interface IAssembleur
    {
        public void AjouterPlatPrincipal(Produit produit);
        public void AjouterBoisson(Produit produit);
        public void AjouterDessert(Produit produit);
    }
}
