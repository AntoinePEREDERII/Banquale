using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Model
{
	[DataContract]
    public class Manager : INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string? propertyName = null)
				=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        [DataMember]
		public HashSet<Customer> CustomersList { get; private set; }

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

        public Transaction SelectedTransaction
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

        private Transaction selectedTransaction;

        

        public IPersistenceManager Persistence { get; set; }

		public Manager(IPersistenceManager persistence)
		{
            CustomersList = new HashSet<Customer>();
			Persistence = persistence;
		}

        public Manager()
        {
            CustomersList = new HashSet<Customer>();
        }

        public bool AddCustomer(Customer MyCustomer)
		{
			CustomersList.Add(MyCustomer);
			return true;
		}

		//public Customer GetCustomer(int place) {
		//		return CustomersList[place];
		//}

        public void DataSave()
        {
            Persistence.DataSave(CustomersList, Consultant);
        }

        public void DataLoad()
		{
			var data = Persistence.DataLoad();

            CustomersList =data.Item1;

			/*foreach (var j in data.Item1)
			{
				CustomersList.Add(j);
			}*/

			Consultant = data.Item2;
		}

    }
}

