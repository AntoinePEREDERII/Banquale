/// \file
/// \brief Fichier de test pour la classe Account.
/// \author Votre nom

using Model;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace UnitTest
{
    /// <summary>
    /// Classe de test pour la classe Account.
    /// </summary>
    public class AccountTest
    {
        /// <summary>
        /// Méthode principale du test.
        /// </summary>
        [Fact]
        public void TestAnAccount()
        {
            // Création de deux comptes
            Account account1 = new Account(1000, "John Doe", "FR123456789");
            Account account2 = new Account(500, "Jane Smith", "FR987654321");

            // Affichage des informations des comptes
            Console.WriteLine("Compte 1:");
            Console.WriteLine($"Nom: {account1.Name}");
            Console.WriteLine($"IBAN: {account1.IBANHide}");
            Console.WriteLine($"Solde: {account1.Balance}");

            Console.WriteLine("\nCompte 2:");
            Console.WriteLine($"Nom: {account2.Name}");
            Console.WriteLine($"IBAN: {account2.IBANHide}");
            Console.WriteLine($"Solde: {account2.Balance}");

            // Effectuer une transaction entre les comptes
            double amount = 200;
            Console.WriteLine($"\nEffectuer une transaction de {amount} du compte 1 vers le compte 2...");
            account1.DoTransactions(account2, amount, true);

            // Affichage des informations des comptes après la transaction
            Console.WriteLine("\nAprès la transaction:");
            Console.WriteLine("Compte 1:");
            Console.WriteLine($"Nom: {account1.Name}");
            Console.WriteLine($"IBAN: {account1.IBANHide}");
            Console.WriteLine($"Solde: {account1.Balance}");

            Console.WriteLine("\nCompte 2:");
            Console.WriteLine($"Nom: {account2.Name}");
            Console.WriteLine($"IBAN: {account2.IBANHide}");
            Console.WriteLine($"Solde: {account2.Balance}");

            // Demander de l'aide
            string helpSubject = "Besoin d'aide";
            string helpDescription = "Je rencontre un problème avec mon compte.";
            Message helpMessage = Account.AskForHelp(helpSubject, helpDescription);
            Console.WriteLine($"\nDemande d'aide envoyée : {helpMessage}");

            // Comparaison de deux comptes
            Console.WriteLine("\nComparaison des comptes...");
            bool areEqual = account1.Equals(account2);
            Console.WriteLine($"Les comptes sont-ils égaux ? {areEqual}");

            //Console.ReadLine();
        }
    }
}
