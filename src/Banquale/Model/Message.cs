using System;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Message
	{
        [DataMember]
        public string Subject { get; private set; }

        [DataMember]
        public string Description { get; private set; }

        public Message(string subject, string description)
        {
            Subject = subject;
            Description = description;
        }

    }
}

