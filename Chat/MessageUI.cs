using Chat.DataAccess;
using Chat.Domain;
using Chat.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.UI
{
    public class MessageUI
    {
        private readonly ChatContext context;
        private readonly MessageService messageService;

        public MessageUI(ChatContext context)
        {
            messageService = new MessageService(context);
        }

        public void Message(User user)
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("=> ");
                    var text = Console.ReadLine();
                    messageService.SendMessage(text, user);
                }
                else if (key.Key == ConsoleKey.F5)
                {
                    Console.Clear();
                    var messages = messageService.UpdateMessages();
                    foreach (var message in messages)
                    {
                        Console.WriteLine($"[{message.CreationDate.TimeOfDay}]{message.User.Login} : {message.Text}");
                    }
                }
            }
        }
    }
}
