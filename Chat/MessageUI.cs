using Chat.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.UI
{
    public class MessageUI
    {
        public void Action()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    MessageService messageService = new MessageService(context);
                    messageService.SendMessage();
                }
            }
        }
    }
}
