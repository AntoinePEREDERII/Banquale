using System;
using Banquale.Model;

namespace Banquale.Stub
{
	public class Stub : IPersistenceManager
	{

        public (List<Customer>, List<Transactions>) DataLoad()
        {
            Customer Customer1 = new Customer("Jacques", "Morice", "J'aimeLesFrites");
            Customer Customer2 = new Customer("Francis", "Begore", "J'aimeLes");
            Customer Customer3 = new Customer("Michel", "Boudout", "MonMdP");
            Console.WriteLine(Customer1);
            List<Customer> CustomersList = new List<Customer>();
            List<Transactions> TransactionsList = new List<Transactions>();
            CustomersList.Add(Customer1);
            CustomersList.Add(Customer2);
            CustomersList.Add(Customer3);
            return (CustomersList, TransactionsList);
        }

        public void DataSave(List<Customer> c, List<Transactions> t)
        {
            throw new NotImplementedException();
        }

    }

}

