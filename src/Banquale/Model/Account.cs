using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Account : INotifyPropertyChanged
    {
	    public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [DataMember(Order = 3)]
        public double Balance 
        {
            get => balance;
            set
            {
                if (balance == value)
                    return;
                balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }
        [DataMember]
        private double balance;


        [DataMember(Order = 1)]
        public string Name 
        {
            get => name;
            set
            {
                if (name == value)
                    return;
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        [DataMember]
        private string name;


        [DataMember(Order = 2)]
        public string IBAN 
        {
            get => iban;
            set
            {
                if (iban == value)
                    return;
                iban = value;
                OnPropertyChanged(nameof(IBAN));
            }
        }
        [DataMember]
        private string iban;

        [DataMember(Order = 4)]
        public string IBANHide
        {
            get => ibanHide;
            set
            {
                if (ibanHide == value)
                    return;
                ibanHide = value;
                OnPropertyChanged(nameof(IBANHide));
            }
        }
        [DataMember]
        private string ibanHide;

        [DataMember(Order = 5)]
        public List<Transaction> TransactionsList 
        { 
            get => transactionsList;
            set
            {
                transactionsList = value;
                OnPropertyChanged(nameof(TransactionsList));
            }
        }

        private List<Transaction> transactionsList;

        public void DoTransactions(Account involvedAccount, double sum, bool type, int nb)
        {
            if (type) // si le type est True => c'est un débit, on doit donc ajouter la transaction pour l'autre compte
            {
                Transaction transaction = new Transaction(type, sum, involvedAccount, nb, DateTime.Now);
                TransactionsList.Add(transaction);
                Balance = Balance-sum;
                involvedAccount.DoTransactions(this, sum, !type, nb+1);
            }
            else // Sinon, c'est un crédit, on a juste à l'ajouter ànotre liste de transactions
            {
                TransactionsList.Add(new Transaction(type, sum, involvedAccount, nb, DateTime.Now));
                Balance = Balance+sum;
            }
            
        }

        public Account(double balance, string name, string iban)
        {
            Balance = balance;
            Name = name;
            IBAN = iban;
            TransactionsList = new List<Transaction>();
            IBANHide = IBANToString();
        }

        //public static void DoTransactions(string name, string iban, string sum)
        //{
        //    Debug.WriteLine(name);
        //    Debug.WriteLine(iban);
        //    Debug.WriteLine(sum);
        //    Debug.WriteLine("Transaction successed !");

        //public bool DoRequest(string name, string IBAN, float sum)
        //{
        //    List<Transactions> transactions.add(sum);
        //    if ()
        //        return true;
        //}

        //public void AskForHelp(string type, string type2, string message)
        //{
        //    Console.WriteLine("Help button pressed !");
        //}

        public static Message AskForHelp(string subject, string description)
        {
            Debug.WriteLine(subject);
            Debug.WriteLine(description);
            Debug.WriteLine("Help button pressed !");
            //throw new NotImplementedException();
            Message message = new Message(subject, description);
            return message;
        }

        public static void DoRequest(string name, string iBAN, string sum)
        {
            throw new NotImplementedException();
        }

        public string IBANToString()
        {
            char[] res = IBAN.ToCharArray();
            for (int i = 5; i< IBAN.Length - 4; i++ )
            {
                if (res[i] == ' ')
                    continue;
                res[i] = '*';
            }
            return new string(res);
        }

        
    }
}
