//using System;
//using Model;

//namespace UnitTest
//{
//    /// \file
//    /// \brief Fichier de tests pour l'interface IPersistenceManager.
//    /// \author Votre nom

//    /// <summary>
//    /// Classe de tests pour l'interface IPersistenceManager.
//    /// </summary>
//    public class PersistenceManagerTests
//    {
//        /// <summary>
//        /// Teste la sauvegarde des données.
//        /// </summary>
//        [Fact]
//        public void DataSave_ValidData_CallsDataSave()
//        {
//            // Arrange
//            MockPersistenceManager persistenceManager = new MockPersistenceManager();
//            List<Customer> customersList = new List<Customer> { new Customer("Doe", "John", "123456") };
//            Consultant consultant = new Consultant("Smith", "Jane", "abcdef");

//            // Act
//            persistenceManager.DataSave(customersList, consultant);

//            // Assert
//            Assert.True(persistenceManager.DataSaveCalled);
//            Assert.Equal(customersList, persistenceManager.SavedCustomersList);
//            Assert.Equal(consultant, persistenceManager.SavedConsultant);
//        }

//        /// <summary>
//        /// Teste le chargement des données.
//        /// </summary>
//        [Fact]
//        public void DataLoad_CallsDataLoad_ReturnsData()
//        {
//            // Arrange
//            MockPersistenceManager persistenceManager = new MockPersistenceManager();
//            List<Customer> customersList = new List<Customer> { new Customer("Doe", "John", "123456") };
//            Consultant consultant = new Consultant("Smith", "Jane", "abcdef");
//            persistenceManager.DataToLoad = (customersList, consultant);

//            // Act
//            var result = persistenceManager.DataLoad();

//            // Assert
//            Assert.True(persistenceManager.DataLoadCalled);
//            Assert.Equal(customersList, result.Item1);
//            Assert.Equal(consultant, result.Item2);
//        }

//        /// <summary>
//        /// Classe de mock pour le gestionnaire de persistance.
//        /// </summary>
//        private class MockPersistenceManager : IPersistenceManager
//        {
//            public bool DataSaveCalled { get; private set; }
//            public bool DataLoadCalled { get; private set; }
//            public (List<Customer>, Consultant) DataToLoad { get; set; }
//            public List<Customer>? SavedCustomersList { get; private set; }
//            public Consultant? SavedConsultant { get; private set; }

//            public void DataSave(List<Customer> customersList, Consultant consultant)
//            {
//                DataSaveCalled = true;
//                SavedCustomersList = customersList;
//                SavedConsultant = consultant;
//            }

//            public (List<Customer>, Consultant) DataLoad()
//            {
//                DataLoadCalled = true;
//                return DataToLoad;
//            }
//        }
//    }
//}
