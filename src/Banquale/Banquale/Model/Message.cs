using System;
namespace Banquale.Model
{
	public class Message
	{

        public string Subject { get; private set; }

        public string Description { get; private set; }

        public Message(string subject, string description)
        {
            Subject = subject;
            Description = description;
        }

    }
}

