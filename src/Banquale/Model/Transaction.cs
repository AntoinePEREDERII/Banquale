using System.ComponentModel;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// Represents a transaction.
    /// </summary>
    [DataContract(IsReference = true)]
    public class Transaction : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Gets or sets the type of the transaction (debit or credit).
        /// </summary>
        [DataMember(Order = 1)]
        public bool Type
        {
            get => type;
            set
            {
                if (type == value)
                    return;
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        [DataMember]
        private bool type;

        /// <summary>
        /// Gets or sets the sum of the transaction.
        /// </summary>
        [DataMember(Order = 2)]
        public double Sum
        {
            get => sum;
            set
            {
                if (sum == value)
                    return;
                sum = value;
                OnPropertyChanged(nameof(Sum));
            }
        }
        [DataMember]
        private double sum;

        /// <summary>
        /// Gets or sets the account(s) involved in the transaction.
        /// </summary>
        [DataMember(Order = 3)]
        public Account? InvolvedAccounts
        {
            get => involvedAccounts;
            set
            {
                if (involvedAccounts == value)
                    return;
                involvedAccounts = value;
                OnPropertyChanged(nameof(InvolvedAccounts));
            }
        }
        [DataMember]
        private Account? involvedAccounts;

        /// <summary>
        /// Gets or sets the category of the transaction.
        /// </summary>
        [DataMember(Order = 4)]
        public string? Category
        {
            get => category;
            set
            {
                if (category == value)
                    return;
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        [DataMember]
        private string? category;

        /// <summary>
        /// Gets or sets the date of the transaction.
        /// </summary>
        [DataMember(Order = 5)]
        public DateTime Date
        {
            get => date;
            set
            {
                if (date == value)
                    return;
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        [DataMember]
        private DateTime date;


        [DataMember(Order = 6)]
        public bool IsOpposition { get; set;  }


        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="type">The type of the transaction (debit or credit).</param>
        /// <param name="sum">The sum of the transaction.</param>
        /// <param name="involvedAccounts">The account(s) involved in the transaction.</param>
        /// <param name="id">The unique identifier of the transaction.</param>
        /// <param name="date">The date of the transaction.</param>
        public Transaction(bool type, double sum, Account involvedAccounts, DateTime date)
        {
            Category = null;
            Type = type;
            Sum = sum;
            InvolvedAccounts = involvedAccounts;
            Date = date;
            IsOpposition = false;
        }

        public void ChangeCategory(string newCateg)
        {
            Category = newCateg;
        }

    }
}
