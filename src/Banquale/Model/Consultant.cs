/// \file
/// \brief Définition de la classe Consultant.
/// \author Votre nom

using System;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// Représente un consultant.
    /// </summary>
    [DataContract]
    public class Consultant : Person
    {
        /// <summary>
        /// Liste des messages du consultant.
        /// </summary>
        [DataMember]
        public List<Message> MessagesList = new List<Message>();

        /// <summary>
        /// Constructeur de la classe Consultant.
        /// </summary>
        /// <param name="name">Nom du consultant.</param>
        /// <param name="firstName">Prénom du consultant.</param>
        /// <param name="password">Mot de passe du consultant.</param>
        public Consultant(string name, string firstName, string password) : base(name, firstName, password)
        {
        }
    }
}
