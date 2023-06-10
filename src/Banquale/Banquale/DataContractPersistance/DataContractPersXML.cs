using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml;


namespace Banquale.DataContractPersistance
{
	public class DataContractPersXML : IPersistenceManager
	{

        public string FilePath { get; set; } = FileSystem.Current.AppDataDirectory;
		public string FileName { get; set; } = "DataSave.xml";

        public (HashSet<Customer>, Consultant) DataLoad()
		{
			var serializer = new DataContractSerializer(typeof(DataToPersist));

			DataToPersist data;

            if (File.Exists(Path.Combine(FilePath, FileName))) // Vérifiez si le fichier existe
            {
                using (Stream s = File.OpenRead(Path.Combine(FilePath, FileName)))
                {
                    data = serializer.ReadObject(s) as DataToPersist;
                }
            }
            else
            {
                data = new DataToPersist(); // Si le fichier n'existe pas, créez une nouvelle liste
            }

            return (data.customer, data.consultant);
		}

		public void DataSave(HashSet<Customer> cu, Consultant co)
		{
            var serializer = new DataContractSerializer(typeof(DataToPersist), new DataContractSerializerSettings() { PreserveObjectReferences = true }); 
            // La deuxième partie sert à faire des références, cela sert à ne pas duppliquer l'écriture de certains attributs

            if (!Directory.Exists(FilePath))
            {
                Debug.WriteLine("Directory doesn't exist.");
                Directory.CreateDirectory(FilePath);
            }


            DataToPersist data = new DataToPersist();
            data.customer = cu;
            data.consultant = co;

            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName)))
            {
                using (XmlWriter w = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(w, data);
                }
            }

        }
    }
}

