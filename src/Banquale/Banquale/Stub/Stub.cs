using System;
using System.Diagnostics;
using Model;

namespace Banquale.Stub
{
    public class Stub : IPersistenceManager
    {

        public (List<Customer>, Consultant) DataLoad()
        {
            Consultant Consultant = new Consultant("Consultant", "Consultant", 0, "Consultant");

            Consultant.MessagesList.Add(new Message("ZUvuzveu", "ZBUBUE"));
            Consultant.MessagesList.Add(new Message("zcdz", "rvri"));
            Consultant.MessagesList.Add(new Message("vjkebor", "rbv"));
            Consultant.MessagesList.Add(new Message("alce", "ubec"));

            Customer Customer1 = new Customer("Jacques", "Morice", "J'aimeLesFrites");
            Customer Customer2 = new Customer("Francis", "Begore", "J'aimeLes");
            Customer Customer3 = new Customer("Michel", "Boudout", "MonMdP");

            Account Account1 = new Account(999, "Tatouille", "FR76 9161 9581 6296 8415 2361 004");
            Account Account2 = new Account(9510, "Despoints", "FR76 4785 8569 6914 4152 5263 003");
            Account Account3 = new Account(3519, "Perotte", "FR76 6352 2541 4169 6958 5847 002");


            Transactions Transactions1 = new Transactions(0, 55, Account1, "Test", new DateTime(2023, 6, 21, 15, 29, 20));
            Transactions Transactions12 = new Transactions(0, 105, Account1, "Test", new DateTime(2023, 8, 17, 18, 54, 35));
            Transactions Transactions13 = new Transactions(0, 187, Account1, "Test", new DateTime(2023, 5, 3, 8, 39, 49));
            Transactions Transactions2 = new Transactions(1, 54.99, Account2, "Test", new DateTime(2022, 8, 15));
            Transactions Transactions3 = new Transactions(0, 1000, Account3, "Test", new DateTime(2020, 9, 1, 20, 00, 00));

            Debug.WriteLine(Customer1.Name, Customer1.Password);
            List<Customer> CustomersList = new List<Customer>();
            List<Transactions> TransactionsList= new List<Transactions>();
            List<Account> AccountsList = new List<Account>();
            


            Account1.TransactionsList.Add(Transactions1);
            Account1.TransactionsList.Add(Transactions12);
            Account1.TransactionsList.Add(Transactions13);
            Account1.TransactionsList.Add(Transactions2);
            Account1.TransactionsList.Add(Transactions3);

            Account2.TransactionsList.Add(Transactions2);

            Customer1.AccountsList.Add(Account1);
            Customer1.AccountsList.Add(Account2);



            CustomersList.Add(Customer1);
            CustomersList.Add(Customer2);
            CustomersList.Add(Customer3);
            return (CustomersList, Consultant);
        }

        public void DataSave(List<Customer> c, Consultant consultant)
        {
            throw new NotImplementedException();
        }

    }

}

