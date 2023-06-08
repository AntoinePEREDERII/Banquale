using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Banquale.DataContractPersistance
{
    public class DataContractPersLINQ : IPersistenceManager
    {

        public string FilePath { get; set; } = FileSystem.Current.AppDataDirectory;
        public string FileName { get; set; } = "DataSave.xml";

        public (HashSet<Customer>, Consultant) DataLoad()
        {
            throw new NotImplementedException();
        }

        public void DataSave(HashSet<Customer> cu, Consultant co)
        {
            XDocument dataSave = new XDocument();

            var save = cu.Select(v => new XElement("Customer",
                                                    new XElement("Personne",
                                                        new XElement("name", v.FirstName),
                                                        new XElement("id", Convert.ToString(v.Id)),
                                                        new XElement("mdp", v.Password),
                                                    new XAttribute("Account", v.AccountsList))));

            dataSave.Add(new XElement("Customers", save));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (TextWriter tw = File.CreateText(Path.Combine(FilePath, FileName)))
            using (XmlWriter writer = XmlWriter.Create(tw, settings))
            {
                dataSave.Save(writer);
            }
        }
    }
}
