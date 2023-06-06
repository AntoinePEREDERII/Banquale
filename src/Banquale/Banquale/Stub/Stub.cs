using System;
using System.Diagnostics;
using Model;

namespace Banquale.Stub
{
    public class Stub : IPersistenceManager
    {

        public (HashSet<Customer>, Consultant) DataLoad()
        {
            Consultant Consultant = new Consultant("Consultant", "Consultant", "Consultant"); // toujours creer en premier le consultant

            Consultant.MessagesList.Add(new Message("ZUvuzveu", "ZBUBUE"));
            Consultant.MessagesList.Add(new Message("zcdz", "rvri"));
            Consultant.MessagesList.Add(new Message("vjkebor", "rbv"));
            Consultant.MessagesList.Add(new Message("alce", "ubec"));

            Customer Customer1 = new Customer("Jacques", "Morice", "Hello");
            Customer Customer2 = new Customer("Francis", "Begore", "Halo");
            Customer Customer3 = new Customer("Michel", "Boudout", "Hola");

            Account Account1 = new Account(999, "Tatouille", "FR7691619581629684152361004");
            Account Account2 = new Account(9510, "Despoints", "FR7647858569691441525263003");
            Account Account3 = new Account(3519, "Perotte", "FR7663522541416969585847002");


            Transaction Transactions1 = new Transaction(true, 55, Account1, 1, new DateTime(2023, 6, 21, 15, 29, 20));
            Transaction Transactions12 = new Transaction(true, 105, Account1, 2, new DateTime(2023, 8, 17, 18, 54, 35));
            Transaction Transactions13 = new Transaction(true, 187, Account1, 3, new DateTime(2023, 5, 3, 8, 39, 49));
            Transaction Transactions2 = new Transaction(false, 54.99, Account2, 4, new DateTime(2022, 8, 15));
            Transaction Transactions3 = new Transaction(true, 1000, Account3, 5, new DateTime(2020, 9, 1, 20, 00, 00));

            Debug.WriteLine(Customer1.Name, Customer1.Password);
            HashSet<Customer> CustomersList = new HashSet<Customer>();
            List<Transaction> TransactionsList= new List<Transaction>();
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

        public void DataSave(HashSet<Customer> c, Consultant consultant)
        {
            throw new NotImplementedException();
        }

    }

}

