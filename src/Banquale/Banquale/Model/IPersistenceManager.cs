using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.Model
{
    public interface IPersistenceManager
    {
        public (List<Customer>, Consultant) DataLoad();

        void DataSave(List<Customer> cu, Consultant co);
    }
}
