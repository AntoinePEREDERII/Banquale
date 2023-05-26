using Banquale.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml;


namespace Banquale.DataContractPersistance
{
	public class DataContractPers : IPersistenceManager
	{
        public string FilePath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/datbase.xml";
		public string FileName { get; set; } = "CustomerList.xml";

		public List<Customer> DataLoad()
		{
			var serializer = new DataContractSerializer(typeof(List<Customer>));

			List<Customer> CustomersList;

			using (Stream s = File.OpenRead(Path.Combine(FilePath, FileName)))
			{
				CustomersList = serializer.ReadObject(s) as List<Customer>;
			}
			return CustomersList;
		}

		public void DataSave(List<Customer> c)
		{
			var serializer = new DataContractSerializer(typeof(List<Customer>));

			if(!Directory.Exists(FilePath))
			{
				Debug.WriteLine("Directory created");
				Debug.WriteLine(FilePath);
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

