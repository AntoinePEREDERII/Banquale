using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banquale.Model
{
    public class Personne
    {
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public int Id { get; private set; }
        public string Mdp { get; private set; }

        public Personne(string nom, string prenom, string mdp)
        {
            Nom = nom;
            Prenom = prenom;
            Id = 0;
            Mdp = mdp;
        }

    }

}
