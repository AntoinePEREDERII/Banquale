using System;

namespace Banquale.Model
{
	public class Manager
	{
		public List<Client> ListeClients { get; private set; }

		public Manager() {
			ListeClients = new List<Client>();
		}

		public bool AjouterClient(Client MonClient)
		{
			ListeClients.Add(MonClient);
			return true;
		}

		public void Donnee()
		{
			Client Client1= new Client("Jacques", "Morice", "J'aimeLesFrites");
			Client Client2 = new Client("Francis", "Begore", "J'aimeLes");
			Client Client3 = new Client("Michel", "Boudout", "MonMdP");
			Console.WriteLine(Client1);
			AjouterClient(Client1);
			AjouterClient(Client2);
			AjouterClient(Client3);
		}
    }
}

