using Chat.DataAccess;
using Chat.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace Chat.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false, true);
            IConfigurationRoot configurationRoot = builder.Build();
            var connectionString = configurationRoot.GetConnectionString("ConnectionString");
            using(ChatContext context = new ChatContext(connectionString))
            {
                Console.WriteLine("Введите логин: ");
                var login = Console.ReadLine();
                var currentUser = context.Users.Single(user => user.Login == login);
                if(currentUser != null)
                {
                    MessageUI messageUI = new MessageUI(context);
                    messageUI.Message(currentUser);
                }
                else
                {
                    Console.WriteLine("Пользователь не найден!");
                }
            }


        }
    }
}
