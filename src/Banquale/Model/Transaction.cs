using System.ComponentModel;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract(IsReference = true)]
    public class Transaction : INotifyPropertyChanged
    {

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [DataMember(Order = 1)]
        public int Id { get; private set; }

        [DataMember(Order = 2)]
        public bool Type
        { 
            get => type;
            set
            {
                if(type == value) 
                    return;
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        [DataMember]

        private bool type;

        [DataMember(Order = 3)]
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

        [DataMember(Order = 4)]
        public Account InvolvedAccounts
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
        private Account involvedAccounts;

        [DataMember(Order = 5)]
        public string Category
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

        [DataMember(Order = 6)]
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

        public Transaction(bool type, double sum, Account involvedAccounts/*, string category*/, int id, DateTime date)
        {
            Type = type;
            Sum = sum;
            Id = id;
            InvolvedAccounts = involvedAccounts;
            //Category = category;
            Date = date;
        }

        public void ChangeCategory(string newCateg)
        {
            Category = newCateg;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
