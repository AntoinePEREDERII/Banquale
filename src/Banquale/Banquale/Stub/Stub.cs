using System;
using System.Diagnostics;
using Model;
using Org.Apache.Http.Cookies;

namespace Banquale.Stub
{
    /// <summary>
    /// Classe de stub pour la gestion de la persistance.
    /// </summary>
    public class Stub : IPersistenceManager
    {
        /// <summary>
        /// Charge les données initiales.
        /// </summary>
        /// <returns>Un tuple contenant la liste des clients et le consultant.</returns>
        public (HashSet<Customer>, Consultant) DataLoad()
        {
            Consultant Consultant = new Consultant("Consultant", "Consultant", "Consultant"); // toujours creer en premier le consultant

            // Ajout des messages au consultant
            Consultant.MessagesList.Add(new Message("Trés bonne application", "Bonjour, je trouve votre application trés cool !"));
            Consultant.MessagesList.Add(new Message("Opposition", "Bonjour, j'ai vu sur mon compte qu'une transaction que je n'ai pas faite a été effectué, j'ai fait une demande d'opposition, pouvez vous l'accepter ?"));
            Consultant.MessagesList.Add(new Message("Compte", "Bonjour, pouvez vous créer un compte pour mon mari s'il vous plaît ?"));
            Consultant.MessagesList.Add(new Message("Bug", "Il y a un bug dans l'application (???)"));

            // création des clients
            Customer Customer1 = new Customer("Carine", "Perrote", "MonMotDePasse"); // Id => 1
            Customer Customer2 = new Customer("Marc", "Despoints", "Halo"); // Id => 2
            Customer Customer3 = new Customer("Lara", "Tatouille", "passwd123"); // Id => 3
            Customer Customer4 = new Customer("Rémi", "Levargne", "poiuytreza"); // Id => 4
            Customer Customer5 = new Customer("Alex", "Travo", "ALEXTRAVO"); // Id => 5

            // Création des comptes et ajout des transactions entre eux
            Account Account1 = new Account(3519, "Perotte", "FR7663522541416969585847002");
            Account Account12 = new Account(199, "Jarque", "FR7691841981629174851361004");

            Account Account2 = new Account(9510, "Despoints", "FR7647858569691441525263003");

            Account Account3 = new Account(1526, "Tatouille", "FR7691619581629684152361004");

            Account Account4 = new Account(5299, "Levargne", "FR7691619589573654128161004");
            Account Account41 = new Account(1822, "Proix", "FR7674859681626354114718003");

            Account Account5 = new Account(90000, "Travo", "FR76954718236512010478103003");

            Debug.WriteLine(Customer1.Name, Customer1.Password);

            // Transactions entre les comptes
            Account1.DoTransactions(Account12, 55, true);
            Account1.DoTransactions(Account12, 585, true);
            Account1.DoTransactions(Account2, 54.99, false);

            Account12.DoTransactions(Account3, 55, true);
            Account12.DoTransactions(Account5, 29, false);

            Account2.DoTransactions(Account41, 149, true);
            Account2.DoTransactions(Account1, 73.95, true);

            Account3.DoTransactions(Account2, 10.9, true);
            Account3.DoTransactions(Account2, 41.57, true);
            Account3.DoTransactions(Account1, 85.21, false);

            Account4.DoTransactions(Account5, 63, true);
            Account4.DoTransactions(Account5, 55, false);

            Account41.DoTransactions(Account1, 60, true);
            Account41.DoTransactions(Account12, 47, false);

            Account5.DoTransactions(Account41, 60.38, true);
            Account5.DoTransactions(Account12, 96.25, false);

            // Ajout des comptes aux clients
            Customer1.AccountsList.Add(Account1);
            Customer1.AccountsList.Add(Account12);

            Customer2.AccountsList.Add(Account2);

            Customer3.AccountsList.Add(Account3);

            Customer4.AccountsList.Add(Account4);
            Customer4.AccountsList.Add(Account41);

            Customer5.AccountsList.Add(Account5);

            // Ajout des clients à la liste des clients
            HashSet<Customer> CustomersList = new HashSet<Customer>();
            CustomersList.Add(Customer1);
            CustomersList.Add(Customer2);
            CustomersList.Add(Customer3);
            CustomersList.Add(Customer4);
            CustomersList.Add(Customer5);

            return (CustomersList, Consultant);
        }

        /// <summary>
        /// Sauvegarde les données.
        /// </summary>
        /// <param name="c">La liste des clients.</param>
        /// <param name="consultant">Le consultant.</param>
        public void DataSave(HashSet<Customer> c, Consultant consultant)
        {
            throw new NotImplementedException();
        }
    }
}
