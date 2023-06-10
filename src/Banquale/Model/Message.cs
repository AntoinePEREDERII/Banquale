/// \file
/// \brief Définition de la classe Message.
/// \author PEREDERII Antoine, LOUVET Titouan

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// Classe représentant un message.
    /// </summary>
    [DataContract]
    public class Message : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string? propertyName = null)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Sujet du message.
        /// </summary>
        [DataMember]
        public string Subject 
        { 
            get => subject;
            set
            {
                if (subject == value) return;
                subject = value;
                OnPropertyChanged();
            }
        }

        private string subject;

        /// <summary>
        /// Description du message.
        /// </summary>
        [DataMember]
        public string Description 
        { 
            get => description;
            set
            {
                if (description == value) return;
                description = value; 
                OnPropertyChanged();
            } 
        }

        private string description;

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
