using System.ComponentModel;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract(IsReference = true)]
    public class Transactions : INotifyPropertyChanged
    {

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [DataMember]
        public int Type
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

        private int type;

        [DataMember]
        public Double Sum 
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
        private Double sum;

        [DataMember]
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

        [DataMember]
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
        private string category;

        [DataMember]
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

        public Transactions(int type, Double sum, Account involvedAccounts, string category, DateTime date)
        {
            Type = type;
            Sum = sum;
            InvolvedAccounts = involvedAccounts;
            Category = category;
            Date = date;
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
