using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.Model
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
        private double balance;


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
        private string iban;


        public Account(int balance, string name, string iban)
        {
            Balance = balance;
            Name = name;
            IBAN = iban;
        }

        [DataMember]
        public List<Transactions> TransactionsList { get; set; } = new List<Transactions>();

        //public bool DoTransactions(string name, string IBAN, float sum)
        //{
        //    List<Transactions> transactions.add(sum);
        //    if()
        //        return true;
        //}

        internal static void DoTransactions(Entry name, Entry iban, Entry sum)
        {
            Debug.WriteLine(name);
            Debug.WriteLine(iban);
            Debug.WriteLine(sum);
            Debug.WriteLine("Transaction successed !");


        }

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

        internal static void AskForHelp(Entry request, Entry subject, Editor message)
        {
            Debug.WriteLine(request.Text);
            Debug.WriteLine(subject);
            Debug.WriteLine(message);
            Debug.WriteLine("Help button pressed !");
            //throw new NotImplementedException();
        }

        internal static void DoRequest(Entry name, Entry iBAN, Entry sum)
        {
            throw new NotImplementedException();
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
