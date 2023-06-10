using Xunit;
using System;

namespace Model.Tests
{
    public class AccountTests
    {
        [Fact]
        public void Account_Initialization_Test()
        {
            // Initialisation
            double initialBalance = 1000.0;
            string accountName = "Gérard";
            string accountIBAN = "FR7612345678901234567895003";

            // Account
            Account account = new Account(initialBalance, accountName, accountIBAN);

            // Assert
            Assert.Equal(initialBalance, account.Balance);
            Assert.Equal(accountName, account.Name);
            Assert.Equal(accountIBAN, account.IBAN);
        }

        [Theory]
        [InlineData(1000.0, 500.0, true, 500.0)] // Debit transaction
        [InlineData(1000.0, 500.0, false, 1500.0)] // Credit transaction
        public void Account_DoTransactions_Test(double initialBalance, double transactionAmount, bool isDebit, double expectedBalance)
        {
            // Initialisation
            Account account = new Account(initialBalance, "Gérard", "FR7612345678901234567895003");
            Account otherAccount = new Account(0.0, "Gérarde", "FR76987654321098765432109876004");

            // Account
            account.DoTransactions(otherAccount, transactionAmount, isDebit);

            // Assert
            Assert.Equal(expectedBalance, account.Balance);
        }

        public static TheoryData<double, double, bool, double> TestData =>
            new TheoryData<double, double, bool, double>
            {
                { 1000.0, 500.0, true, 500.0 }, // Debit transaction
                { 1000.0, 500.0, false, 1500.0 }, // Credit transaction
            };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Account_DoTransactions_MemberData_Test(double initialBalance, double transactionAmount, bool isDebit, double expectedBalance)
        {
            // Initialisation
            Account account = new Account(initialBalance, "Gérard", "FR7612345678901234567895003");
            Account otherAccount = new Account(0.0, "Gérarde", "FR76987654321098765432109876004");

            // Account
            account.DoTransactions(otherAccount, transactionAmount, isDebit);

            // Assert
            Assert.Equal(expectedBalance, account.Balance);
        }
    }
}
