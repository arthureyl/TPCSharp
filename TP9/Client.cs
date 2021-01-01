using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    //IV.1 Créez une classe abstraite Client, avec les attributs nom, prénom de
    //sorte que les attributs ne puissent pas être modifiés.
    public abstract class Client
    {

        private string _nom;
        private string _prenom;

        public string Nom { get => _nom; }
        public string Prenom { get => _prenom; }

        protected Client(string nom, string prenom)
        {
            _nom = FormaterNom(nom);
            _prenom = FormaterPrenom(prenom);
        }



        //IV.2 Créer une méthode privée statique qui permette de formater le
        //prénom, une méthode privée statique permettant de formatter le
        //nom, et appelez ces méthodes dans le constructeur pour que le nom et
        //prénom soient correctement formatés, quelle que soit la saisie par
        //l’utilisateur.
        private static String FormaterNom(String nom)
        {
            nom = nom.ToUpper();
            return nom;
        }

        private static String FormaterPrenom(String prenom)
        {
            prenom = char.ToUpper(prenom[0]) + prenom[1..].ToLower();
            return prenom;
        }

        //IV.3 Créez une seule fonction GetName() qui retourne le nom suivi du
        //prénom. Le prénom devra avoir la première lettre en majuscule et les
        //suivantes en minuscule (sans caractères spéciaux), le nom devra être
        //entièrement en majuscules(sans caractères spéciaux)
        public string GetName()
        {
            return Nom + " " + Prenom;
        }


        //IV.4 (Bonus) Surcharger l’opérateur == pour pouvoir comparer si deux
        //objets de la classe client sont égaux. (le nom et le prénom sont égaux)
        public override bool Equals(object obj)
        {
            Client client = (Client) obj;
            if (Nom == client.Nom && Prenom == client.Prenom)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
