using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class Etudiant : Client
    {
        //VI.1 Créez une classe Étudiant qui hérite de client, et qui possède en plus
        //une année de diplôme(l’année d’obtention du diplôme)
        private int _anneeDiplome;

        public int AnneeDiplome { get => _anneeDiplome; }

        //VI.2 Les objets de cette classe seront considérés comme membres du BDE,
        //et bénéficieront du tarif réduit.

        //VI.3 Créez le constructeur qui permette ceci tout en initialisant les
        //membres de la classe mère « Client ».
        public Etudiant(string nom, string prenom, int anneeDiplome) : base(nom,prenom)
        {
            _anneeDiplome = anneeDiplome;
        }

    }
}
