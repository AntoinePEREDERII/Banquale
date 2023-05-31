using System;
using Banquale.Model;

namespace Banquale.DataContractPersistance
{
	public class DataToPersist
	{
		public List<Customer> customer { get; set; } = new List<Customer>();
		public Consultant consultant { get; set; } = null;
	}
}

