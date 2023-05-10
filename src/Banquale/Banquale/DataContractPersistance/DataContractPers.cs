using System;


namespace Banquale.DataContractPersistance
{
	public class DataContractPers
	{
		public DataContractPers()
		{
			public string Filename { get; set; } = "PATH";

			public string FilePath { get; set; } = "PATH";

		}

		public (List<Client>, List<Transactions>) ChargeDonnee()
		{
			var serializer = new DataContractSerializer(typeof(Client));
		}
	}
}

