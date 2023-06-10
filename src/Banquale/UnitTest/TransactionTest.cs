/// \file
/// \brief Fichier de test pour la classe Transaction.
/// \author PEREDERII Antoine

using System;
using System.Collections.Generic;
using Model;
using Xunit;

namespace UnitTest
{
    /// <summary>
    /// Tests for the <see cref="Transaction"/> class.
    /// </summary>
    public class TransactionTest
    {
        /// <summary>
        /// Tests the initialization of a transaction with the specified parameters.
        /// </summary>
        [Fact]
        public void Transaction_Initialization()
        {
            // Arrange
            bool type = true;
            double sum = 100.0;
            Account involvedAccounts = new Account(10, "Bonjour", "FR1234567890123456789012343");
            DateTime date = DateTime.Now;

            // Act
            Transaction transaction = new Transaction(type, sum, involvedAccounts, date);

            // Assert
            Assert.Equal(type, transaction.Type);
            Assert.Equal(sum, transaction.Sum);
            Assert.Equal(involvedAccounts, transaction.InvolvedAccounts);
            Assert.Equal(date, transaction.Date);
            Assert.False(transaction.IsOpposition);
        }

        /// <summary>
        /// Tests changing the category of a transaction.
        /// </summary>
        [Fact]
        public void ChangeCategory_ChangesCategory()
        {
            // Arrange
            Transaction transaction = new Transaction(true, 100.0, new Account(100, "Monsieur", "FR1234567890190456789012343"), DateTime.Now);
            string newCategory = "NewCategory";

            // Act
            transaction.ChangeCategory(newCategory);

            // Assert
            Assert.Equal(newCategory, transaction.Category);
        }

        /// <summary>
        /// Tests the transaction type using inline data.
        /// </summary>
        /// <param name="type">The transaction type.</param>
        /// <param name="expectedResult">The expected result.</param>
        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void Transaction_Type(bool type, bool expectedResult)
        {
            // Arrange
            Transaction transaction = new Transaction(type, 100.0, new Account(1000, "Hello", "FR1212567890190456789012343"), DateTime.Now);

            // Act
            bool result = transaction.Type;

            // Assert
            Assert.Equal(expectedResult, result);
        }

        /// <summary>
        /// Tests the sum of the transaction using inline data.
        /// </summary>
        /// <param name="sum">The sum of the transaction.</param>
        [Theory]
        [InlineData(100.0)]
        [InlineData(200.0)]
        public void Transaction_Sum(double sum)
        {
            // Arrange
            Transaction transaction = new Transaction(true, sum, new Account(100, "Monsieur", "FR1234567890190456789012343"), DateTime.Now);

            // Act
            double result = transaction.Sum;

            // Assert
            Assert.Equal(sum, result);
        }

        /// <summary>
        /// Tests the transaction category using member data.
        /// </summary>
        /// <param name="category">The transaction category.</param>
        [Theory]
        [MemberData(nameof(GetTransactionCategories))]
        public void Transaction_Category(string category)
        {
            // Arrange
            Transaction transaction = new Transaction(true, 100.0, new Account(100, "Monsieur", "FR1234567890190456789012343"), DateTime.Now);

            // Act
            transaction.ChangeCategory(category);
            string result = transaction.Category;

            // Assert
            Assert.Equal(category, result);
        }

        /// <summary>
        /// Provides test data for transaction categories.
        /// </summary>
        /// <returns>The list of transaction categories.</returns>
        public static IEnumerable<object[]> GetTransactionCategories()
        {
            yield return new object[] { "Category1" };
            yield return new object[] { "Category2" };
        }
    }
}

