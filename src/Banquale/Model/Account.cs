/// \file
/// \brief Définition de la classe Account.
/// \author Votre nom

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Représente un compte bancaire.
    /// </summary>
    [DataContract]
    public class Account : INotifyPropertyChanged
    {
        /// <summary>
        /// Événement déclenché lorsqu'une propriété est modifiée.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Déclenche l'événement PropertyChanged pour une propriété donnée.
        /// </summary>
        /// <param name="propertyName">Nom de la propriété modifiée.</param>
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Obtient ou définit le solde du compte.
        /// </summary>
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

        /// <summary>
        /// Obtient ou définit le nom du titulaire du compte.
        /// </summary>
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

        /// <summary>
        /// Obtient ou définit le numéro IBAN du compte.
        /// </summary>
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

        /// <summary>
        /// Obtient une version masquée du numéro IBAN du compte.
        /// </summary>
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

        /// <summary>
        /// Obtient ou définit la liste des transactions effectuées sur le compte.
        /// </summary>
        [DataMember(Order = 5)]
        public ObservableCollection<Transaction> TransactionsList 
        {
            get => transactionsList;
            set
            {
                transactionsList = value;
                OnPropertyChanged(nameof(TransactionsList));
            } 
        } 

        private ObservableCollection<Transaction> transactionsList;

        /// <summary>
        /// Effectue une transaction entre le compte courant et un compte tiers.
        /// </summary>
        /// <param name="involvedAccount">Compte tiers impliqué dans la transaction.</param>
        /// <param name="sum">Somme de la transaction.</param>
        /// <param name="type">Type de transaction (débit ou crédit).</param>
        public void DoTransactions(Account involvedAccount, double sum, bool type)
        {
            if (type) // si le type est True => c'est un débit, on doit donc ajouter la transaction pour l'autre compte
            {
                Transaction transaction = new Transaction(type, sum, involvedAccount, DateTime.Now);
                TransactionsList.Add(transaction);
                Balance = Balance - sum;
                involvedAccount.DoTransactions(this, sum, !type);
            }
            else // Sinon, c'est un crédit, on a juste à l'ajouter à notre liste de transactions
            {
                TransactionsList.Add(new Transaction(type, sum, involvedAccount, DateTime.Now));
                Balance = Balance + sum;
            }
        }

        /// <summary>
        /// Constructeur de la classe Account.
        /// </summary>
        /// <param name="balance">Solde initial du compte.</param>
        /// <param name="name">Nom du titulaire du compte.</param>
        /// <param name="iban">Numéro IBAN du compte.</param>
        public Account(Double balance, string name, string iban)
        {
            Balance = balance;
            Name = name;
            IBAN = iban;
            IBANHide = IBANToString();
            TransactionsList = new ObservableCollection<Transaction>();
        }

        /// <summary>
        /// Demande d'aide pour un compte.
        /// </summary>
        /// <param name="subject">Sujet de la demande d'aide.</param>
        /// <param name="description">Description de la demande d'aide.</param>
        /// <returns>Un message d'aide.</returns>
        public static Message AskForHelp(string subject, string description)
        {
            Debug.WriteLine(subject);
            Debug.WriteLine(description);
            Debug.WriteLine("Help button pressed !");
            Message message = new Message(subject, description);
            return message;
        }

        /// <summary>
        /// Convertit le numéro IBAN en une version masquée.
        /// </summary>
        /// <returns>Le numéro IBAN masqué.</returns>
        public string IBANToString()
        {
            char[] res = IBAN.ToCharArray();
            for (int i = 5; i < IBAN.Length - 4; i++)
            {
                if (res[i] == ' ')
                    continue;
                res[i] = '*';
            }
            return new string(res);
        }


        /// <summary>
        /// Vérifie si deux comptes sont égaux en comparant leur numéro IBAN.
        /// </summary>
        /// <param name="other">Compte à comparer.</param>
        /// <returns>True si les comptes sont égaux, False sinon.</returns>
        public bool Equals(Account other)
        {
            if (other == null) return false;
            else return other.IBAN.Equals(IBAN);
        }

        /// <summary>
        /// Obtient le code de hachage du compte basé sur le numéro IBAN.
        /// </summary>
        /// <returns>Le code de hachage.</returns>
        public override int GetHashCode()
        {
            return IBAN.GetHashCode();
        }
    }
}
