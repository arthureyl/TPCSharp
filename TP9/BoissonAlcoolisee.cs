using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{

    //BoissonAlcoolisee, qui contient une propriété « degré d’alcool »
    //(Les produits de ce type ne peuvent pas être vendus aux clients
    //mineurs).
    public class BoissonAlcoolisee : Produit
    {
        private decimal _degreAlcool;

        public decimal DegreAlcool { get => _degreAlcool; }
        public BoissonAlcoolisee(string nom, decimal prixAchat, decimal prixVenteMembre, decimal prixVenteNonMembre, decimal degreAlcool) : base(nom, prixAchat, prixVenteMembre, prixVenteNonMembre)
        {
            _degreAlcool = degreAlcool;
            this.Emballage = "Bouteille";
        }
    }
}
