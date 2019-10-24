using System;
using System.Collections.Generic;
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

        public void SendMessage(string message, User user)
        {
            var message = new Message
            {
                User = user, 
                Text = message,
            };
            context.Message.Add(message);
            context.SaveChanges();
        }

        public ICollection<Message> UpdateMessages()
        {
            var allMessage = context.Messages.ToList();
            return allMessage;
        }
    }
}
