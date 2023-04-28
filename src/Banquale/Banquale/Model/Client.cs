using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banquale.Model
{
    
    class Client: Personne
    {
        public Client(string nom, string prenom, string mdp) : base(nom, prenom, mdp)
        {
            
        }

        public List<Compte> ListeComptes{ get; private set; }


    }
}
