using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{


    //Développez une classe qui permette de modéliser un produit. Un
    //produit possède un nom, un prix d’achat, un prix de vente pour les
    //membres, et un prix de vente pour les non-membres. Ces attributs ne
    //peuvent plus être modifiés après la création d’un objet.
 
    public abstract class Produit : IPackaging
    {
        private string _nom;
        private decimal _prixAchat;
        private decimal _prixVenteMembre;
        private decimal _prixVenteNonMembre;
        private string _emballage;

        public Produit(string nom, decimal prixAchat, decimal prixVenteMembre, decimal prixVenteNonMembre)
        {
            _nom = nom;
            _prixAchat = prixAchat;
            _prixVenteMembre = prixVenteMembre;
            _prixVenteNonMembre = prixVenteNonMembre;
        }

        public string Nom { get => _nom; }
        public decimal PrixAchat { get => _prixAchat; }
        public decimal PrixVenteMembre { get => _prixVenteMembre; }
        public decimal PrixVenteNonMembre { get => _prixVenteNonMembre; }
        public string Emballage { get => _emballage; set => _emballage = value; }
    }
}
