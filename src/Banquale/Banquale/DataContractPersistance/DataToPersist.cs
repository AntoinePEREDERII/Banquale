using System;
using Model;

namespace Banquale.DataContractPersistance
{
	public class DataToPersist
	{
		public HashSet<Customer> customer { get; set; } = new HashSet<Customer>();
		public Consultant consultant { get; set; }
	}
}

