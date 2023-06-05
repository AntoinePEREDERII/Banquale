using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Model
{
	[DataContract]
    public class Manager : INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
				=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        [DataMember]
		public List<Customer> CustomersList { get; private set; } // devient un set

        [DataMember]
        public Consultant Consultant { get; private set; } // 1 SEUL consultant

		public bool IsConsultant { get; set; } = false;

        public Customer SelectedCustomer
		{
			get => selectedCustomer;
			set
			{
				if (selectedCustomer == value)
					return;
				selectedCustomer = value;
				OnPropertyChanged();
			}
		}

		private Customer selectedCustomer;

		public Account SelectedAccount
		{
			get => selectedAccount;
			set
			{
                if (selectedAccount == value)
                    return;
                selectedAccount = value;
                OnPropertyChanged();
            }
		}

		private Account selectedAccount;

        public Transactions SelectedTransaction
        {
            get => selectedTransaction;
            set
            {
                if (selectedTransaction == value)
                    return;
                selectedTransaction = value;
                OnPropertyChanged();
            }
        }

        private Transactions selectedTransaction;

        

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

			/*foreach (var j in data.Item1)
			{
				CustomersList.Add(j);
			}*/

			Consultant = data.Item2;
		}

    }
}

