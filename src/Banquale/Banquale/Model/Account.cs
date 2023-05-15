using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banquale.Model
{
    public class Account
    {
        public int Balance { get; set; }

        public string Name { get; set;}

        public string IBAN { get; set; }

        public List<Transactions> TransactionsList { get; set; }
    }
}
