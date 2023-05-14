using System;
using Banquale.Model;

namespace Banquale.DataContractPersistance
{
	public class DataToPersist
	{
			public List<Client> clients { get; set; } = new List<Client>();
            public List<Transactions> transactions { get; set; } = new List<Transactions>();
	}
}

