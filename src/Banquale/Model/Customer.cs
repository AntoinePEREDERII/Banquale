using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System;
using System.Threading.Tasks;


namespace Model
{
    [DataContract]
    public class Customer : Person, IEquatable<Customer>//, IComparable<Customer>
    {
        [DataMember]
        public List<Account> AccountsList { get; private set; } = new List<Account>();

        //private uint NbAccounts { get; set; } = AccountsList.Count;


        public Customer(string name, string firstName, string password) : base(name, firstName, password)
        {}


        public bool Equals(Customer? other)
        {
            if (other == null) return false;
            else return other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

}
