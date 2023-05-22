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

        //private uint NbAccounts { get; set; } = AccountsList.Count;


        public Customer(string name, string firstName, string password) : base(name, firstName, password)
        {}

        


    }

}
