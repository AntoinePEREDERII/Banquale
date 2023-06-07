using Model;
using System;

namespace UnitTest
{
    /// <summary>
    /// Classe de test pour la classe Message.
    /// </summary>
    public class MessageTest
    {
        /// <summary>
        /// Point d'entrée du programme de test.
        /// </summary>
        /// <param name="args">Arguments de ligne de commande.</param>
        [Fact]
        public void TestAMessage()
        {
            // Création d'un message
            Message message = new Message("Important", "Ceci est un message important.");

            // Affichage des informations du message
            Console.WriteLine("Message:");
            Console.WriteLine($"Sujet: {message.Subject}");
            Console.WriteLine($"Description: {message.Description}");

            Console.ReadLine();
        }
    }
}
