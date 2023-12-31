﻿/// \file
/// \brief Définition de la classe Customer.
/// \author PEREDERII Antoine, LOUVET Titouan

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// Représente un client.
    /// </summary>
    [DataContract]
    public class Customer : Person, IEquatable<Customer>//, IComparable<Customer>
    {
        /// <summary>
        /// Liste des comptes du client.
        /// </summary>
        [DataMember]
        public List<Account> AccountsList { get; private set; } = new List<Account>();

        /// <summary>
        /// Constructeur de la classe Customer.
        /// </summary>
        /// <param name="name">Nom du client.</param>
        /// <param name="firstName">Prénom du client.</param>
        /// <param name="password">Mot de passe du client.</param>
        public Customer(string name, string firstName, string password) : base(name, firstName, password)
        {}


        public bool Equals(Customer? other)
        {
            if (other == null) return false;
            else return other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
