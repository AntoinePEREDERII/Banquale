using System;
using System.Runtime.Serialization;

namespace Banquale.Model
{
	[DataContract]
	public class Manager
	{
		[DataMember]
		public List<Customer> CustomersList { get; private set; }

		[DataMember]
        public List<Transactions> TransactionsList { get; private set; }

		public List<Account> AccountList { get; private set; }

        public IPersistenceManager Persistence { get; set; }

		public Manager(IPersistenceManager persistence) {

            TransactionsList = new List<Transactions>();
            CustomersList = new List<Customer>();
			Persistence = persistence;

		}

        public Manager()
        {
            CustomersList = new List<Customer>();
			TransactionsList = new List<Transactions>();
        }

        public bool AddCustomer(Customer MyCustomer)
		{
			CustomersList.Add(MyCustomer);
			return true;
		}

		public Customer GetCustomer(int place) {
				return CustomersList[place];
		}

        public void DataSave()
        {
            Persistence.DataSave(CustomersList);
        }

        public void DataLoad()
		{
			var data = Persistence.DataLoad();

			CustomersList.AddRange(data);

			foreach (var j in data)
			{
				CustomersList.Add(j);
			}
			/*
			foreach (var i in data.Item2)
			{
				TransactionsList.Add(i);
			}*/
		}

    }
}

