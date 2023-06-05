﻿using System;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Consultant : Person
	{
        [DataMember]
        public List<Message> MessagesList = new List<Message>();

        public Consultant(string name, string firstName, string password) : base(name, firstName, password)
        {
		}
	}
}

