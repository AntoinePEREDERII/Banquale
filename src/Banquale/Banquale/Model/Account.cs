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

        public int Balance { get; set; }

        public string Name { get; set;}

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double Solde 
        {
            get => solde;
            set
            {
                if (solde == value)
                    return;
                solde = value;
                OnPropertyChanged(nameof(Solde));
            }
        }
        private double solde;

        

        public string Nom 
        {
            get => nom;
            set
            {
                if (nom == value)
                    return;
                nom = value;
                OnPropertyChanged(nameof(Nom));
            }
        }
        private string nom;

        public string IBAN 
        {
            get => iBAN;
            set
            {
                if (iBAN == value)
                    return;
                iBAN = value;
                OnPropertyChanged(nameof(IBAN));
            }
        }
        private string iBAN;


        public Compte(int solde, string nom, string iBAN)
        {
            Solde = solde;
            Nom = nom;
            IBAN = iBAN;
        }
        public List<Transactions> TransactionsList { get; set; }
    }
}
