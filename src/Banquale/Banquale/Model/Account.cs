using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.Model
{
    public class Account : INotifyPropertyChanged
    {
	public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double Balance 
        {
            get => Balance;
            set
            {
                if (balance == value)
                    return;
                balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }
        private double balance;

        

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

        public List<Transactions> TransactionsList { get; set; }

        //public bool DoTransactions(string name, string IBAN, float sum)
        //{
        //    List<Transactions> transactions.add(sum);
        //    if()
        //        return true;
        //}

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
            Console.WriteLine(request);
            Console.WriteLine(subject);
            Console.WriteLine(message);
            Console.WriteLine("Help button pressed !");
            //throw new NotImplementedException();
        }
    }
}
