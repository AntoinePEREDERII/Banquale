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
    public class DataContractPersJSON : IPersistenceManager
    {

        public string FilePath { get; set; } = FileSystem.Current.AppDataDirectory;
        public string FileName { get; set; } = "DataSave.json";


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
                            true))//<- this boolean says that we sant indentation
                {
                    jsonSerializer.WriteObject(writer, data);
                }
            }
        }
    }
}
