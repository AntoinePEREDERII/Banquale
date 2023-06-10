/// \file
/// \brief Définition de la classe Person.
/// \author PEREDERII Antoine, LOUVET Titouan

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// Classe représentant une personne.
    /// </summary>
    [DataContract]
    public class Person
    {
        /// <summary>
        /// Nom de la personne.
        /// </summary>
        [DataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Prénom de la personne.
        /// </summary>
        [DataMember]
        public string FirstName { get; private set; }

        /// <summary>
        /// Identifiant de la personne.
        /// </summary>
        [DataMember]
        public uint Id { get; private set; }

        /// <summary>
        /// Compteur d'identifiants.
        /// </summary>
        public static uint id { get; set; } = 0;

        /// <summary>
        /// Mot de passe de la personne.
        /// </summary>
        [DataMember]
        public string Password { get; private set; }

        /// <summary>
        /// Constructeur de la classe Person.
        /// </summary>
        /// <param name="name">Nom de la personne.</param>
        /// <param name="firstName">Prénom de la personne.</param>
        /// <param name="password">Mot de passe de la personne.</param>
        public Person(string name, string firstName, string password)
        {
            Name = name;
            FirstName = firstName;
            Id = id;
            Password = password;
            id++;
        }
    }
}
