using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Banquale.DataContractPersistance
{
    // Nous ne pouvons utiliser la persitance avec JSON dans notre application car la persitance avec JSON n'accepte pas
    // les références, nous sommes pourtant obligé d'utiliser des références pour la sauvegarde des transactions


    /// <summary>
    /// Gestionnaire de persistance avec JSON utilisant DataContract.
    /// </summary>
    public class DataContractPersJSON : IPersistenceManager
    {
        /// <summary>
        /// Chemin du fichier de sauvegarde.
        /// </summary>
        public string FilePath { get; set; } = FileSystem.Current.AppDataDirectory;

        /// <summary>
        /// Nom du fichier de sauvegarde.
        /// </summary>
        public string FileName { get; set; } = "DataSave.json";

        /// <summary>
        /// Charge les données sauvegardées.
        /// </summary>
        /// <returns>Tuple contenant la liste des clients et le consultant.</returns>
        public (HashSet<Customer>, Consultant) DataLoad()
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(DataToPersist));

            DataToPersist data;

            using (FileStream stream2 = File.OpenRead(Path.Combine(FilePath, FileName)))
            {
                data = jsonSerializer.ReadObject(stream2) as DataToPersist;
            }

            return (data.customer, data.consultant);
        }

        /// <summary>
        /// Sauvegarde les données.
        /// </summary>
        /// <param name="cu">Liste des clients.</param>
        /// <param name="co">Consultant.</param>
        public void DataSave(HashSet<Customer> cu, Consultant co)
        {
            DataToPersist data = new DataToPersist();
            data.customer = cu;
            data.consultant = co;

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(DataToPersist));
            using (FileStream stream = File.Create(Path.Combine(FilePath, FileName)))
            {
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(
                            stream,
                            System.Text.Encoding.UTF8,
                            false,
                            true)) // <- this boolean says that we want indentation
                {
                    jsonSerializer.WriteObject(writer, data);
                }
            }
        }
    }
}
