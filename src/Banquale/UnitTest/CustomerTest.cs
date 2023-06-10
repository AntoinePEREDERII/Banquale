//using System;
//using Model;

//namespace UnitTest
//{
//    /// \file
//    /// \brief Fichier de tests pour la classe Customer.
//    /// \author Votre nom

//    /// <summary>
//    /// Classe de tests pour la classe Customer.
//    /// </summary>
//    public class CustomerTests
//    {
//        /// <summary>
//        /// Teste si la liste des comptes du client est initialisée correctement.
//        /// </summary>
//        [Fact]
//        public void Constructor_AccountsListInitialized()
//        {
//            // Arrange
//            string name = "Doe";
//            string firstName = "John";
//            string password = "123456";

//            // Act
//            Customer customer = new Customer(name, firstName, password);

//            // Assert
//            Assert.NotNull(customer.AccountsList);
//            Assert.Empty(customer.AccountsList);
//        }

//        /// <summary>
//        /// Teste l'égalité entre deux clients.
//        /// </summary>
//        [Fact]
//        public void Equals_TwoEqualCustomers_ReturnsTrue()
//        {
//            // Arrange
//            string name1 = "Doe";
//            string firstName1 = "John";
//            string password1 = "123456";
//            string name2 = "Doe";
//            string firstName2 = "John";
//            string password2 = "123456";

//            // Act
//            Customer customer1 = new Customer(name1, firstName1, password1);
//            Customer customer2 = new Customer(name2, firstName2, password2);

//            // Assert
//            Assert.True(customer1.Equals(customer2));
//        }

//        /// <summary>
//        /// Teste l'égalité entre deux clients avec des identifiants différents.
//        /// </summary>
//        [Fact]
//        public void Equals_TwoDifferentCustomers_ReturnsFalse()
//        {
//            // Arrange
//            string name1 = "Doe";
//            string firstName1 = "John";
//            string password1 = "123456";
//            string name2 = "Smith";
//            string firstName2 = "Jane";
//            string password2 = "abcdef";

//            // Act
//            Customer customer1 = new Customer(name1, firstName1, password1);
//            Customer customer2 = new Customer(name2, firstName2, password2);

//            // Assert
//            Assert.False(customer1.Equals(customer2));
//        }
//    }
//}
