using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.Model
{
    public class Transactions : INotifyPropertyChanged
    {

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
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

        private int type;

        public Double Somme 
        {
            get => somme;
            set
            {
                if (somme == value)
                    return;
                somme = value;
                OnPropertyChanged(nameof(Somme));
            }
        }
        private Double somme;

        public Compte CompteImplique 
        {
            get => compteImplique;
            set
            {
                if (compteImplique == value)
                    return;
                compteImplique = value;
                OnPropertyChanged(nameof(CompteImplique));
            }
        }
        private Compte compteImplique;

        public string Categorie 
        {
            get => categorie;
            set
            {
                if (categorie == value)
                    return;
                categorie = value;
                OnPropertyChanged(nameof(Categorie));
            }
        }
        private string categorie;

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
        private DateTime date;

        public Transactions(int type, Double somme, Compte compteImplique, string categorie, DateTime date) { 
            Type = type;
            Somme = somme;
            CompteImplique = compteImplique;
            Categorie = categorie;
            Date = date;
        public int Sum { get; private set; }

        public Account InvolvedAccounts { get; private set; }

        public string Category { get; private set; }

        public Transactions(int type, int sum, Account involvedAccounts, string category) { 
            Type = type;
            Sum = sum;
            InvolvedAccounts = involvedAccounts;
            Category = category;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
