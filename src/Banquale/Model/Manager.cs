/// \file
/// \brief Définition de la classe Manager.
/// \author Votre nom

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// Classe représentant le gestionnaire du système.
    /// </summary>
    [DataContract]
    public class Manager : INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string? propertyName = null)
				=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Liste des clients gérés par le gestionnaire.
        /// </summary>
        [DataMember]
        public List<Customer> CustomersList { get; private set; } // devient un set

        /// <summary>
        /// Consultant assigné au gestionnaire.
        /// </summary>
        [DataMember]
        public Consultant Consultant { get; private set; } // 1 SEUL consultant

        /// <summary>
        /// Indique si le gestionnaire est un consultant.
        /// </summary>
        public bool IsConsultant { get; set; } = false;

        /// <summary>
        /// Client sélectionné par le gestionnaire.
        /// </summary>
        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                if (selectedCustomer == value)
                    return;
                selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        private Customer selectedCustomer;

        /// <summary>
        /// Compte sélectionné par le gestionnaire.
        /// </summary>
        public Account SelectedAccount
        {
            get => selectedAccount;
            set
            {
                if (selectedAccount == value)
                    return;
                selectedAccount = value;
                OnPropertyChanged();
            }
        }

        private Account selectedAccount;

        /// <summary>
        /// Transaction sélectionnée par le gestionnaire.
        /// </summary>
        public Transaction SelectedTransaction
        {
            get => selectedTransaction;
            set
            {
                if (selectedTransaction == value)
                    return;
                selectedTransaction = value;
                OnPropertyChanged();
            }
        }

        private Transaction selectedTransaction;

        /// <summary>
        /// Gestionnaire de persistance utilisé par le gestionnaire.
        /// </summary>
        public IPersistenceManager Persistence { get; set; }

        /// <summary>
        /// Constructeur du gestionnaire avec un gestionnaire de persistance spécifié.
        /// </summary>
        /// <param name="persistence">Gestionnaire de persistance.</param>
        public Manager(IPersistenceManager persistence)
        {
            CustomersList = new List<Customer>();
            Persistence = persistence;
        }

        /// <summary>
        /// Constructeur du gestionnaire sans gestionnaire de persistance.
        /// </summary>
        public Manager()
        {
            CustomersList = new List<Customer>();
        }

        /// <summary>
        /// Ajoute un client à la liste des clients gérés par le gestionnaire.
        /// </summary>
        /// <param name="myCustomer">Client à ajouter.</param>
        /// <returns>True si l'ajout est réussi, sinon False.</returns>
        public bool AddCustomer(Customer myCustomer)
        {
            CustomersList.Add(myCustomer);
            return true;
        }

        /// <summary>
        /// Récupère le client à la position spécifiée dans la liste des clients.
        /// </summary>
        /// <param name="place">Position du client.</param>
        /// <returns>Le client à la position spécifiée.</returns>
        public Customer GetCustomer(int place)
        {
            return CustomersList[place];
        }

        /// <summary>
        /// Enregistre les données dans la source de persistance.
        /// </summary>
        public void DataSave()
        {
            Persistence.DataSave(CustomersList, Consultant);
        }

        /// <summary>
        /// Charge les données depuis la source de persistance.
        /// </summary>
        public void DataLoad()
        {
            var data = Persistence.DataLoad();

            CustomersList.AddRange(data.Item1);

            Consultant = data.Item2;
        }
    }
}
