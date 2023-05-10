using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Banquale.Model;

namespace Banquale.DataContractPersistance
{
	public class DataContractPers : IPersistanceManager
	{

		public string FileName { get; set; } = "ClientAndTransactionsList.xml";

		public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML1_folder")/*"/Users/Perederii/SAE/Banquale/src/Banquale/Banquale/XML_folder"*/;


		public (List<Client>, List<Transactions>) ChargeDonnee()
		{
			var serializer = new DataContractSerializer(typeof(List<Client>));

			List<Client> ListClients;

			using (Stream s = File.OpenRead(Path.Combine(FilePath, FileName)))
			{
				ListClients = serializer.ReadObject(s) as List<Client>;
			}
			return (ListClients, new List<Transactions>());
		}

		public void SauvegardeDonnee(List<Client> c, List<Transactions> t)
		{
			var serializer = new DataContractSerializer(typeof(List<Client>));

			if(!Directory.Exists(FilePath))
			{
				Debug.WriteLine("Directory crée à l'instant");
				Debug.WriteLine(Directory.GetDirectoryRoot);
				Debug.WriteLine(FilePath);
				Directory.CreateDirectory(FilePath);
			}

			using (Stream s = File.Create(Path.Combine(FilePath, FileName)))
			{
				serializer.WriteObject(s, t);
			}
		}
    }
}

