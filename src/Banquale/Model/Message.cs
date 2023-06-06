/// \file
/// \brief Définition de la classe Message.
/// \author Votre nom

using System;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// Classe représentant un message.
    /// </summary>
    [DataContract]
    public class Message
    {
        /// <summary>
        /// Sujet du message.
        /// </summary>
        [DataMember]
        public string Subject { get; private set; }

        /// <summary>
        /// Description du message.
        /// </summary>
        [DataMember]
        public string Description { get; private set; }

        /// <summary>
        /// Constructeur de la classe Message.
        /// </summary>
        /// <param name="subject">Sujet du message.</param>
        /// <param name="description">Description du message.</param>
        public Message(string subject, string description)
        {
            Subject = subject;
            Description = description;
        }
    }
}
