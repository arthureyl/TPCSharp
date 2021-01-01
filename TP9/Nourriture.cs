using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class Nourriture : Produit
    {
        public Nourriture(string nom, decimal prixAchat, decimal prixVenteMembre, decimal prixVenteNonMembre) : base(nom, prixAchat, prixVenteMembre, prixVenteNonMembre)
        {
            this.Emballage = "Sachet";
        }
    }
}
