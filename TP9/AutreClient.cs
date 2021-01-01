using System;
using System.Collections.Generic;
using System.Text;

namespace TP9
{
    public class AutreClient : Client
    {
        //VII.1 Les clients représentés par cette classe ne bénéficieront pas d’un
        //tarif préférentiel

        //VII.2 Créez une classe AutreClient qui hérite de client, mais n’a pas de
        //diplôme.


        public AutreClient(String firstname, String lastname) : base(firstname, lastname)
        {
        }

    }
}
