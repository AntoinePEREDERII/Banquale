using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.Model
{
    public class Transactions
    {
        public int Type { get; private set; }

        public int Sum { get; private set; }

        public Account InvolvedAccounts { get; private set; }

        public string Category { get; private set; }

        public Transactions(int type, int sum, Account involvedAccounts, string category) { 
            Type = type;
            Sum = sum;
            InvolvedAccounts = involvedAccounts;
            Category = category;
        }
    }
}
