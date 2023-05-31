using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Banquale.Model
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public string FirstName { get; private set; }
        [DataMember]
        public uint Id { get; private set; }
        [DataMember]
        public string Password { get; private set; }

        public Person(string name, string firstName, string password)
        {
            Name = name;
            FirstName = firstName;
            Id = 1;
            Password = password;
        }

        public Person(string name, string firstName, uint id, string password)
        {
            Name = name;
            FirstName = firstName;
            Id = id;
            Password = password;
        }

    }

}
