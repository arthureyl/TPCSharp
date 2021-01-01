using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class FormuleRepas
    {
        private List<Produit> _formule;

        public List<Produit> Formule { get => _formule; set => _formule = value; }

        public FormuleRepas()
        {
            Formule = new List<Produit>();
        }

        public void AjouterProduit(Produit produit)
        {
            Formule.Add(produit);
        }

        public decimal PrixFormuleNomMembre()
        {
            decimal prixFormuleNonMembre = 0;
            foreach(var produit in Formule)
            {
                prixFormuleNonMembre += produit.PrixVenteNonMembre;
            }

            return prixFormuleNonMembre;
        }

        public decimal PrixFormuleMembre()
        {
            decimal prixFormuleMembre = 0;
            foreach (var produit in Formule)
            {
                prixFormuleMembre += produit.PrixVenteMembre;
            }

            return prixFormuleMembre;
        }

        public override string ToString()
        {
            string formuleCarte = "";
            foreach (var produit in Formule)
            {
                formuleCarte += "\n"+produit.Nom;
            }
            return formuleCarte;
        }
    }
}
