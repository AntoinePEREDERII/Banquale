/// \file
/// \brief Fichier de test pour la classe Transaction.
/// \author Votre nom

using Model;
using System;

namespace UnitTest
{
    /// <summary>
    /// Classe de test pour la classe Transaction.
    /// </summary>
    public class TransactionTest
    {
        /// <summary>
        /// Méthode principale du test.
        /// </summary>
        [Fact]
        public void TestATransaction()
        {
            // Création d'un compte
            Account account = new Account(1000, "John Doe", "FR123456789");

            // Création d'une transaction
            Transaction transaction = new Transaction(true, 200, account, 1, DateTime.Now);

            // Affichage des informations de la transaction
            Console.WriteLine("Transaction:");
            Console.WriteLine($"Type: {(transaction.Type ? "Débit" : "Crédit")}");
            Console.WriteLine($"Somme: {transaction.Sum}");
            Console.WriteLine($"Compte impliqué: {transaction?.InvolvedAccounts?.Name}");
            Console.WriteLine($"Catégorie: {transaction?.Category}");
            Console.WriteLine($"Date: {transaction?.Date}");

            Console.ReadLine();
        }
    }
}
