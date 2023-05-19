using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Banquale.Model
{
    [DataContract]
    public class Client: Personne
    {
        [DataMember]
        public List<Compte> ListeComptes { get; private set; }


        public Client(string nom, string prenom, string mdp) : base(nom, prenom, mdp)
        {}

        //public bool DoTransactions(string name, string IBAN, float montant)
        //{
        //    List<Transactions> transactions.add(montant);
        //    if ()
        //        return true;
        //}

        //public bool DoRequest(string name, string IBAN, float montant)
        //{
        //    List<Transactions> transactions.add(montant);
        //    if ()
        //        return true;
        //}


    }

}
