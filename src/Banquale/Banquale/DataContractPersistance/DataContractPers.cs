using Banquale.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml;


namespace Banquale.DataContractPersistance
{
	public class DataContractPers : IPersistanceManager
	{
        //Partie Antoine
        public string FilePath { get; set; } = "/Users//Perederii//SAE//Banquale//src//Banquale//Banquale//Persistances";
		public string FileName { get; set; } = "ClientAndTransactionsList.xml";

		//public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML1_folder")/*"/Users/Perederii/SAE/Banquale/src/Banquale/Banquale/XML_folder"*/;

		//Partie Titouan

		//public string FileName { get; set; } = "nomFichier.xml";
		
  //      public string FilePath2 { get; set; } = "..\\Persistances";
  //      public string FilePath { get; set; } = "C:\\Users\\louve\\depot\\Banquale\\src\\Banquale\\Persistances";

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
				Directory.CreateDirectory(FilePath);
			}

			var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName))) 
			{
				using (XmlWriter writer = XmlWriter.Create(tw, settings))
				{
					serializer.WriteObject(writer, c);
				}
			}
        }
    }
}

