using System;

namespace Banquale.Model
{
	public class Manager
	{
		public List<Client> ListeClients { get; private set; }


        public List<Transactions> ListeTransactions { get; private set; }

        public IPersistanceManager Persistance { get; set; }

		public Manager(IPersistanceManager persistance) {

            ListeTransactions = new List<Transactions>();
            ListeClients = new List<Client>();
			Persistance = persistance;

		}

        public Manager()
        {
            ListeClients = new List<Client>();
			ListeTransactions = new List<Transactions>();
        }

        public bool AjouterClient(Client MonClient)
		{
			ListeClients.Add(MonClient);
			return true;
		}

		public Client GetClient(int place) {
				return ListeClients[place];
		}

        public void sauvegardeDonnee()
        {
            Persistance.SauvegardeDonnee(ListeClients, ListeTransactions);
        }

        public void ChargeDonnee()
		{
			var donnees = Persistance.ChargeDonnee();

			ListeClients.AddRange(donnees.Item1);
			ListeTransactions.AddRange(donnees.Item2);

			foreach (var j in donnees.Item1)
			{
				ListeClients.Add(j);
			}
			foreach (var i in donnees.Item2)
			{
				ListeTransactions.Add(i);
			}
		}

    }
}

