using System;
using System.Runtime.Serialization;

namespace Banquale.Model
{
	[DataContract]
	public class Manager
	{
		[DataMember]
		public List<Customer> CustomersList { get; private set; } // devient un set

		public Consultant Consultant { get; private set; } // 1 SEUL consultant

        public Customer SelectedCustomer
		{
			get => selectedCustomer;
			set
			{
				selectedCustomer = value;
			}
		}

		private Customer selectedCustomer;

		public Account SelectedAccount
		{
			get => selectedAccount;
			set
			{
				selectedAccount = value;
			}
		}

		private Account selectedAccount;

        public IPersistenceManager Persistence { get; set; }

		public Manager(IPersistenceManager persistence)
		{
            CustomersList = new List<Customer>();
			Persistence = persistence;
		}

        public Manager()
        {
            CustomersList = new List<Customer>();
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
            Persistence.DataSave(CustomersList, Consultant);
        }

        public void DataLoad()
		{
			var data = Persistence.DataLoad();

			CustomersList.AddRange(data.Item1);

			foreach (var j in data.Item1)
			{
				CustomersList.Add(j);
			}

			Consultant = data.Item2;
		}

    }
}

