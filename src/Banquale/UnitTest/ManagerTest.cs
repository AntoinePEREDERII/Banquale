/// \file
/// \brief Définition des tests pour la classe Consultant.
/// \author PEREDERII Antoine, LOUVET Titouan

using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UnitTest;
using Xunit;

namespace UnitTest
{
    /// <summary>
    /// Classe de tests pour la classe Manager.
    /// </summary>
    public class ManagerTests
    {
        private class PersistenceManagerMock : IPersistenceManager
        {
            public (HashSet<Customer>, Consultant) DataLoad()
            {
                // Implémentez la logique de chargement des données
                // Retournez les données chargées (HashSet<Customer>, Consultant)
                throw new System.NotImplementedException();
            }

            public void DataSave(HashSet<Customer> customers, Consultant consultant)
            {
                // Implémentez la logique d'enregistrement des données
                // Utilisez les paramètres customers et consultant pour enregistrer les données
                throw new System.NotImplementedException();
            }
        }

        [Fact]
        public void AddCustomer_ReturnsTrue()
        {
            // Arrange
            IPersistenceManager persistenceManager = new PersistenceManagerMock();
            Manager manager = new Manager(persistenceManager);
            Customer customer = new Customer("A", "B", "C");

            // Act
            bool result = manager.AddCustomer(customer);

            // Assert
            Assert.True(result);
            // Ajoutez plus d'assertions au besoin
        }

        public static IEnumerable<object[]> DataForAddCustomer()
        {
            yield return new object[] { new Customer("A", "B", "C") };
            yield return new object[] { new Customer("B", "C", "D") };
        }

        [Theory]
        [MemberData(nameof(DataForAddCustomer))]
        public void AddCustomer_ReturnsTrueWithMemberData(Customer customer)
        {
            // Arrange
            IPersistenceManager persistenceManager = new PersistenceManagerMock();
            Manager manager = new Manager(persistenceManager);

            // Act
            bool result = manager.AddCustomer(customer);

            // Assert
            Assert.True(result);
            // Ajoutez plus d'assertions au besoin
        }

        [Theory]
        [InlineData("John", "Doe", "Consultant")]
        [InlineData("Jane", "Smith", "Manager")]
        public void AddCustomer_ReturnsTrueWithInlineData(string firstName, string lastName, string role)
        {
            // Arrange
            IPersistenceManager persistenceManager = new PersistenceManagerMock();
            Manager manager = new Manager(persistenceManager);
            Customer customer = new Customer(firstName, lastName, role);

            // Act
            bool result = manager.AddCustomer(customer);

            // Assert
            Assert.True(result);
            // Ajoutez plus d'assertions au besoin
        }
    }
}
