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
    /// <summary>
    /// Classe de gestion de persistance utilisant LINQ.
    /// </summary>
    public class DataContractPersLINQ : IPersistenceManager
    {
        /// <summary>
        /// Chemin du fichier de sauvegarde.
        /// </summary>
        public string FilePath { get; set; } = FileSystem.Current.AppDataDirectory;

        /// <summary>
        /// Nom du fichier de sauvegarde.
        /// </summary>
        public string FileName { get; set; } = "DataSave.xml";

        /// <summary>
        /// Charge les données à partir du fichier de sauvegarde.
        /// </summary>
        /// <returns>Un tuple contenant la liste des clients et le consultant.</returns>
        public (HashSet<Customer>, Consultant) DataLoad()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sauvegarde les données dans le fichier de sauvegarde.
        /// </summary>
        /// <param name="cu">Liste des clients à sauvegarder.</param>
        /// <param name="co">Consultant à sauvegarder.</param>
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
