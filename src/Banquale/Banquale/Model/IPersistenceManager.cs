using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.Model
{
    public interface IPersistenceManager
    {
        public (List<Customer>, List<Transactions>) DataLoad();

        void DataSave(List<Customer> c, List<Transactions> t /*, List<Account> c2*/);
    }
}
