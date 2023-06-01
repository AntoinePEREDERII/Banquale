using System;
using System.Runtime.Serialization;

namespace Banquale.Model
{
    [DataContract]
    public class Consultant : Person
	{
        [DataMember]
        public List<Message> MessagesList = new List<Message>();

        public Consultant(string name, string firstName, uint id, string password) : base(name, firstName, id, password)
        {
		}
	}
}

