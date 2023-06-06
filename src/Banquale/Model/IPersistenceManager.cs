using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Model
{
    public interface IPersistenceManager
    {
        public (HashSet<Customer>, Consultant) DataLoad();

        void DataSave(HashSet<Customer> cu, Consultant co);
    }
}
