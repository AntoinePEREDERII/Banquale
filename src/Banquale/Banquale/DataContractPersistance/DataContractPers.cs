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
		public string FileName { get; set; } = "nomFichier.xml";

        public string FilePath2 { get; set; } = "..\\Persistances";
        public string FilePath { get; set; } = "C:\\Users\\louve\\depot\\Banquale\\src\\Banquale\\Persistances";



        public (List<Client>, List<Transactions>) ChargeDonnee()
		{
			var serializer = new DataContractSerializer(typeof(List<Client>));
			List<Client> list;

			using (Stream s = File.OpenRead(Path.Combine(FilePath, FileName)))
			{
				list = serializer.ReadObject(s) as List<Client>;
			}

			return (list, new List<Transactions>());
		}

        public void SauvegardeDonnee(List<Client> c, List<Transactions> t)
        {
            var serializer = new DataContractSerializer (typeof(List<Client>));
			if(!Directory.Exists(FilePath))
			{
				Debug.WriteLine("Directory non crée");
				Debug.WriteLine(Directory.GetDirectoryRoot(FilePath));
				Debug.WriteLine(FilePath);
				Directory.CreateDirectory(FilePath);
			}

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName))) 
			{
				using (XmlWriter writer = XmlWriter.Create(tw, settings))
				{
					serializer.WriteObject(writer, t);
				}
			}
        }
    }
}

