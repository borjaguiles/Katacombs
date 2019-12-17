using System;

namespace Katacombs
{
    public class Message
    {
        private string _title;
        private string _description;

        public Message(string title, string description)
        {
            _title = title;
            _description = description;
        }

        public Message(string description)
        {
            _description = description;
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(_title))
            {
                return _description;
            }

            return _title + Environment.NewLine + _description;
        }
    }
}
