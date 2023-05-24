﻿using System;
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
        public int Id { get; private set; }
        [DataMember]
        public string Password { get; private set; }

        public Person(string name, string firstName, string password)
        {
            Name = name;
            FirstName = firstName;
            Id = 0;
            Password = password;
        }

    }

}