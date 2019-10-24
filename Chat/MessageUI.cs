using Chat.DataAccess;
using Chat.Domain;
using Chat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat.UI
{
    public class MessageUI
    {
        private const int messagePerPage = 20;
        private readonly ChatContext context;
        private readonly MessageService messageService;

        public MessageUI(ChatContext context)
        {
            messageService = new MessageService(context);
        }

        public void Message(User user)
        {
            ShowMessages();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("\n=> ");
                    var text = Console.ReadLine();
                    messageService.SendMessage(text, user);
                }
                else if (key.Key == ConsoleKey.F5)
                {
                    ShowMessages();
                }
            }
        }

        private void ShowMessages()
        {
            Console.Clear();
            var messageCount = messageService.UpdateMessages().Count - messagePerPage;

            var messages = context.Messages.Skip(messageCount).Take(messagePerPage).ToList();
            foreach(var message in messages) 
            { 
                Console.WriteLine($"[{message.CreationDate.TimeOfDay}]{message.User.Login} : {message.Text}");
            }

        }
    }
}
