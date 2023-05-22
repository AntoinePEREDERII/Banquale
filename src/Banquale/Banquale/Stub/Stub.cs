using System;
using Banquale.Model;

namespace Banquale.Stub
{
    public class Stub : IPersistenceManager
    {

        public (List<Customer>, List<Transactions> /*, List<Account>*/) DataLoad()
        {
            Customer Customer1 = new Customer("Jacques", "Morice", "J'aimeLesFrites");
            Customer Customer2 = new Customer("Francis", "Begore", "J'aimeLes");
            Customer Customer3 = new Customer("Michel", "Boudout", "MonMdP");

            Account Account1 = new Account(999, "Tatouille", "FR76 9161 9581 6296 8415 2361 004");
            Account Account2 = new Account(9510, "Despoints", "FR76 4785 8569 6914 4152 5263 003");
            Account Account3 = new Account(3519, "Perotte", "FR76 6352 2541 4169 6958 5847 002");


            Transactions Transactions1 = new Transactions(0, 55, Account1, "Test", new DateTime(2023, 6, 21));
            Transactions Transactions2 = new Transactions(1, 54.99, Account2, "Test", new DateTime(2022, 8, 15));
            Transactions Transactions3 = new Transactions(0, 1000, Account3, "Test", new DateTime(2020, 9, 1));

            Console.WriteLine(Customer1);
            List<Customer> CustomersList = new List<Customer>();
            List<Transactions> TransactionsList= new List<Transactions>();
            List<Account> AcountsList = new List<Account>();
            AcountsList.Add(Account1);
            AcountsList.Add(Account2);
            AcountsList.Add(Account3);

            CustomersList.Add(Customer1);
            CustomersList.Add(Customer2);
            CustomersList.Add(Customer3);
            return (CustomersList, TransactionsList /*, AccountsList*/);
        }

        public void DataSave(List<Customer> c, List<Transactions> t)
        {
            throw new NotImplementedException();
        }

    }

}

