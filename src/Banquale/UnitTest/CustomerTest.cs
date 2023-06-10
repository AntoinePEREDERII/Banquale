/// \file
/// \brief Définition des tests pour la classe Customer.
/// \author PEREDERII Antoine, LOUVET Titouan

using Xunit;
using System;
using Model;

namespace UnitTest
{
    /// <summary>
    /// Classe de tests pour la classe Customer.
    /// </summary>
    public class CustomerTests
    {
        /// <summary>
        /// Teste si la liste des comptes du client est initialisée correctement.
        /// </summary>
        [Fact]
        public void Constructor_AccountsListInitialized()
        {
            // Initialisation
            string name = "Cust";
            string firstName = "Gérard";
            string password = "123456";

            // Act
            Customer customer = new Customer(name, firstName, password);

            // Assert
            Assert.NotNull(customer.AccountsList);
            Assert.Empty(customer.AccountsList);
        }

        /// <summary>
        /// Teste si la liste des comptes du client est initialisée correctement en utilisant InlineData.
        /// </summary>
        /// <param name="name">Nom du client.</param>
        /// <param name="firstName">Prénom du client.</param>
        /// <param name="password">Mot de passe du client.</param>
        [Theory]
        [InlineData("Cust", "Gérard", "123456")]
        public void Constructor_AccountsListInitialized_InlineData(string name, string firstName, string password)
        {
            // Act
            Customer customer = new Customer(name, firstName, password);

            // Assert
            Assert.NotNull(customer.AccountsList);
            Assert.Empty(customer.AccountsList);
        }

        /// <summary>
        /// Fournit les données pour le test de l'initialisation de la liste des comptes du client.
        /// </summary>
        public static TheoryData<string, string, string> TestData =>
            new TheoryData<string, string, string>
            {
                { "Cust", "Gérard", "123456" },
            };

        /// <summary>
        /// Teste si la liste des comptes du client est initialisée correctement en utilisant MemberData.
        /// </summary>
        /// <param name="name">Nom du client.</param>
        /// <param name="firstName">Prénom du client.</param>
        /// <param name="password">Mot de passe du client.</param>
        [Theory]
        [MemberData(nameof(TestData))]
        public void Constructor_AccountsListInitialized_MemberData(string name, string firstName, string password)
        {
            // Act
            Customer customer = new Customer(name, firstName, password);

            // Assert
            Assert.NotNull(customer.AccountsList);
            Assert.Empty(customer.AccountsList);
        }
    }
}
