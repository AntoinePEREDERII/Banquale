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
    public class Account : INotifyPropertyChanged, IEquatable<Account>
    {
	    public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [DataMember]
        public Double Balance 
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
        private Double balance;


        [DataMember]
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


        [DataMember]
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

        [DataMember]
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

        [DataMember]
        public List<Transactions> TransactionsList { get; set; } = new List<Transactions>();

        public void DoTransactions(Account involvedAccount, Double sum, bool type, int nb)
        {
            if (type) // si le type est True => c'est un débit, on doit donc ajouter la transaction pour l'autre compte
            {
                Transactions transaction = new Transactions(type, sum, involvedAccount, nb, DateTime.Now);
                TransactionsList.Add(transaction);
                Balance = Balance-sum;
                involvedAccount.DoTransactions(this, sum, !type, nb+1);
            }
            else // Sinon, c'est un crédit, on a juste à l'ajouter ànotre liste de transactions
            {
                TransactionsList.Add(new Transactions(type, sum, involvedAccount, nb, DateTime.Now));
                Balance = Balance+sum;
            }
            
        }

        public Account(Double balance, string name, string iban)
        {
            Balance = balance;
            Name = name;
            IBAN = iban;
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

        public bool Equals(Account other)
        {
            if(other == null) return false;
            else return other.IBAN.Equals(IBAN);
        }

        public override int GetHashCode()
        {
            return IBAN.GetHashCode();
        }
    }
}
