using System;
using Banquale.Model;

namespace Banquale.Stub
{
	public class Stub : IPersistanceManager
	{

        (List<Client>, List<Transactions>) IPersistanceManager.ChargeDonnee()
        {
            Client Client1 = new Client("Jacques", "Morice", "J'aimeLesFrites");
            Client Client2 = new Client("Francis", "Begore", "J'aimeLes");
            Client Client3 = new Client("Michel", "Boudout", "MonMdP");
            Console.WriteLine(Client1);
            List<Client> ListeClients = new List<Client>();
            ListeClients.Add(Client1);
            ListeClients.Add(Client2);
            ListeClients.Add(Client3);
            return ListeClients;
        }

        void IPersistanceManager.SauvegardeDonnee(List<Client> c, List<Transactions> t)
        {
            throw new NotImplementedException();
        }

    }

}

