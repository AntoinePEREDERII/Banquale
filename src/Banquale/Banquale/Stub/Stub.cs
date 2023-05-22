using System;
using Banquale.Model;

namespace Banquale.Stub
{
    public class Stub : IPersistanceManager
    {

        public (List<Client>, List<Transactions> /*, List<Compte>*/) ChargeDonnee()
        {
            Client Client1 = new Client("Jacques", "Morice", "J'aimeLesFrites");
            Client Client2 = new Client("Francis", "Begore", "J'aimeLes");
            Client Client3 = new Client("Michel", "Boudout", "MonMdP");

            Compte Compte1 = new Compte(999, "Tatouille", "FR76 9161 9581 6296 8415 2361 004");
            Compte Compte2 = new Compte(9510, "Despoints", "FR76 4785 8569 6914 4152 5263 003");
            Compte Compte3 = new Compte(3519, "Perotte", "FR76 6352 2541 4169 6958 5847 002");


            Transactions Transactions1 = new Transactions(0, 55, Compte1, "Test", new DateTime(2023, 6, 21));
            Transactions Transactions2 = new Transactions(1, 54.99, Compte2, "Test", new DateTime(2022, 8, 15));
            Transactions Transactions3 = new Transactions(0, 1000, Compte3, "Test", new DateTime(2020, 9, 1));

            Console.WriteLine(Client1);
            List<Client> ListeClients = new List<Client>();
            List<Transactions> ListeTransactions = new List<Transactions>();
            //List<Compte> ListeCompte = new List<Compte>();
            //ListeCompte.Add( Compte1 );
            //ListeCompte.Add(Compte2);
            //ListeCompte.Add(Compte3);

            ListeClients.Add(Client1);
            ListeClients.Add(Client2);
            ListeClients.Add(Client3);
            return (ListeClients, ListeTransactions /*, ListeCompte*/);
        }

        public void SauvegardeDonnee(List<Client> c, List<Transactions> t)
        {
            throw new NotImplementedException();
        }

    }

}

