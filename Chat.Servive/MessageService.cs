using Chat.DataAccess;
using Chat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat.Service
{
    public class MessageService
    {
        private readonly ChatContext context;

        public MessageService(ChatContext context)
        {
            this.context = context;
        }

        public void SendMessage(string text, User user)
        {
            if (text == "") return;
            var message = new Message
            {
                User = user,
                Text = text,
            };
            context.Messages.Add(message);
            context.SaveChanges();
        }

        public ICollection<Message> UpdateMessages()
        {
            var allMessage = context.Messages.ToList();
            return allMessage;
        }
    }
}
