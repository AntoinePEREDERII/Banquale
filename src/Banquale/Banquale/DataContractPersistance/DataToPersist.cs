using System;
using Model;

namespace Banquale.DataContractPersistance
{
    /// <summary>
    /// Classe de données à persister.
    /// </summary>
    public class DataToPersist
    {
        /// <summary>
        /// Liste des clients à persister.
        /// </summary>
        public HashSet<Customer> customer { get; set; } = new HashSet<Customer>();

        /// <summary>
        /// Consultant à persister.
        /// </summary>
        public Consultant consultant { get; set; }
    }
}