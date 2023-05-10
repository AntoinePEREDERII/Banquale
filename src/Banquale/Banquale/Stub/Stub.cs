using System;
using Banquale.Model;

namespace Banquale.Stub
{
	public class Stub : IPersistanceManager
	{

        public (List<Client>, List<Transactions>) ChargeDonnee()
        {
            Client Client1 = new Client("Jacques", "Morice", "J'aimeLesFrites");
            Client Client2 = new Client("Francis", "Begore", "J'aimeLes");
            Client Client3 = new Client("Michel", "Boudout", "MonMdP");
            Console.WriteLine(Client1);
            List<Client> ListeClients = new List<Client>();
            List<Transactions> ListeTransactions = new List<Transactions>();
            ListeClients.Add(Client1);
            ListeClients.Add(Client2);
            ListeClients.Add(Client3);
            return (ListeClients, ListeTransactions);
        }

        public void SauvegardeDonnee(List<Client> c, List<Transactions> t)
        {
            throw new NotImplementedException();
        }

    }

}

