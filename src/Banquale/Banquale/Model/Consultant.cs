using System;
namespace Banquale.Model
{
	public class Consultant : Person
	{

		public List<Message> MessagesList = new List<Message>();

        public Consultant(string name, string firstName, uint id, string password) : base(name, firstName, id, password)
        {
		}
	}
}

