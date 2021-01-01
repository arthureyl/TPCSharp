using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class Boisson : Produit
    {
        public Boisson(string nom, decimal prixAchat, decimal prixVenteMembre, decimal prixVenteNonMembre) : base(nom, prixAchat, prixVenteMembre, prixVenteNonMembre)
        {
            this.Emballage = "Bouteille";
        }
    }
}
