using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Domain
{
    public class Message : Entity
    {
        public string Text { get; set; }
        public User User { get; set; }
    }
}
