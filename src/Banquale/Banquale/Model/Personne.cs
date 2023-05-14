using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Banquale.Model
{
    [DataContract]
    public class Personne
    {
        [DataMember]
        public string Nom { get; private set; }
        [DataMember]
        public string Prenom { get; private set; }
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
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
