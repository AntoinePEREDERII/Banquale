using System;
using Banquale.Model;

namespace Banquale.DataContractPersistance
{
	public class DataToPersist
	{
			public List<Customer> customer { get; set; } = new List<Customer>();
            public List<Transactions> transactions { get; set; } = new List<Transactions>();
	}
}

