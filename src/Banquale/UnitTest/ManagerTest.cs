using System;
using Model;

namespace UnitTest
{
    /// \file
    /// \brief Fichier de tests pour la classe Manager.
    /// \author Votre nom

    /// <summary>
    /// Classe de tests pour la classe Manager.
    /// </summary>
    public class ManagerTests
    {
        /// <summary>
        /// Teste si la liste des clients est initialisée correctement.
        /// </summary>
        [Fact]
        public void Constructor_CustomersListInitialized()
        {
            // Arrange
            Manager manager = new Manager();

            // Act

            // Assert
            Assert.NotNull(manager.CustomersList);
            Assert.Empty(manager.CustomersList);
        }

        /// <summary>
        /// Teste l'ajout d'un client à la liste des clients.
        /// </summary>
        [Fact]
        public void AddCustomer_ValidCustomer_ReturnsTrue()
        {
            // Arrange
            Manager manager = new Manager();
            Customer customer = new Customer("Doe", "John", "123456");

            // Act
            bool result = manager.AddCustomer(customer);

            // Assert
            Assert.True(result);
            Assert.Contains(customer, manager.CustomersList);
        }

        /// <summary>
        /// Teste la récupération d'un client à partir de la liste des clients.
        /// </summary>
        [Fact]
        public void GetCustomer_ValidPosition_ReturnsCustomer()
        {
            // Arrange
            Manager manager = new Manager();
            Customer customer1 = new Customer("Doe", "John", "123456");
            Customer customer2 = new Customer("Smith", "Jane", "abcdef");
            manager.AddCustomer(customer1);
            manager.AddCustomer(customer2);

            // Act
            Customer result = manager.GetCustomer(1);

            // Assert
            Assert.Equal(customer2, result);
        }

        /// <summary>
        /// Teste la sauvegarde des données.
        /// </summary>
        [Fact]
        public void DataSave_ValidData_CallsPersistenceManagerDataSave()
        {
            // Arrange
            MockPersistenceManager persistenceManager = new MockPersistenceManager();
            Manager manager = new Manager(persistenceManager);
            Customer customer = new Customer("Doe", "John", "123456");
            manager.AddCustomer(customer);

            // Act
            manager.DataSave();

            // Assert
            Assert.True(persistenceManager.DataSaveCalled);
            Assert.Equal(manager.CustomersList, persistenceManager.SavedCustomersList);
            Assert.Equal(manager.Consultant, persistenceManager.SavedConsultant);
        }

        /// <summary>
        /// Teste le chargement des données.
        /// </summary>
        [Fact]
        public void DataLoad_ValidData_CallsPersistenceManagerDataLoad()
        {
            // Arrange
            MockPersistenceManager persistenceManager = new MockPersistenceManager();
            Manager manager = new Manager(persistenceManager);
            Customer customer = new Customer("Doe", "John", "123456");
            Consultant consultant = new Consultant("Smith", "Jane", "abcdef");
            persistenceManager.DataToLoad = (new List<Customer> { customer }, consultant);

            // Act
            manager.DataLoad();

            // Assert
            Assert.True(persistenceManager.DataLoadCalled);
            Assert.Contains(customer, manager.CustomersList);
            Assert.Equal(consultant, manager.Consultant);
        }

        /// <summary>
        /// Classe de mock pour le gestionnaire de persistance.
        /// </summary>
        private class MockPersistenceManager : IPersistenceManager
        {
            public bool DataSaveCalled { get; private set; }
            public bool DataLoadCalled { get; private set; }
            public (List<Customer>, Consultant) DataToLoad { get; set; }
            public List<Customer>? SavedCustomersList { get; private set; }
            public Consultant? SavedConsultant { get; private set; }

            public void DataSave(List<Customer> customersList, Consultant consultant)
            {
                DataSaveCalled = true;
                SavedCustomersList = customersList;
                SavedConsultant = consultant;
            }

            public (List<Customer>, Consultant) DataLoad()
            {
                DataLoadCalled = true;
                return DataToLoad;
            }
        }
    }
}
