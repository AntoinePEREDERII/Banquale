using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Banquale.Model
{
    [DataContract]
    public class Customer : Person
    {
        [DataMember]
        public List<Account> AccountsList { get; private set; }


        public Customer(string name, string firstName, string password) : base(name, firstName, password)
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
