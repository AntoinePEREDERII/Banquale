using System;
namespace Banquale.Model
{
	public class Manager
	{
		public List<Client> ListeClients { get; private set;}

		public Manager() {

		}

		public bool AjouterClient(Client MonClient)
		{
			ListeClients.Add(MonClient);
			return true;
		}

	}
}

