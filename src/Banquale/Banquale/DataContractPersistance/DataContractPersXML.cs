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
        //public string FilePath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/datbase.xml";

        public string FilePath { get; set; } = FileSystem.Current.AppDataDirectory;
		public string FileName { get; set; } = "DataSave.xml";

        public (List<Customer>, Consultant) DataLoad()
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

   //         List<Customer> CustomersList;
			//Consultant Consultant;

			//using (Stream s = File.OpenRead(Path.Combine(FilePath, FileNameCustomer)))
			//{
			//	CustomersList = serializer.ReadObject(s) as List<Customer>;
   //         }

   //         using (Stream s = File.OpenRead(Path.Combine(FilePath, FileNameConsultant)))
   //         {
   //             Consultant = serializer2.ReadObject(s) as Consultant;
   //         }

            return (data.customer, data.consultant);
		}

		public void DataSave(List<Customer> cu, Consultant co)
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


   //         var serializer = new DataContractSerializer(typeof(List<Customer>));
   //         var serializer2 = new DataContractSerializer(typeof(Consultant));

   //         if (!Directory.Exists(FilePath))
			//{
			//	Debug.WriteLine("Directory created");
			//	Debug.WriteLine(FilePath);
			//	Directory.CreateDirectory(FilePath);
			//}

			//var settings = new XmlWriterSettings() { Indent = true };
   //         using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileNameCustomer))) 
			//{
			//	using (XmlWriter writer = XmlWriter.Create(tw, settings))
			//	{
			//		serializer.WriteObject(writer, cu);
			//	}
			//}

   //         using (TextWriter tw2 = File.CreateText(Path.Combine(FilePath, FileNameConsultant)))
   //         {
   //             using (XmlWriter writer2 = XmlWriter.Create(tw2, settings))
   //             {
   //                 serializer.WriteObject(writer2, co);
   //             }
   //         }
        }
    }
}

