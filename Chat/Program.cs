using Chat.DataAccess;
using Chat.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

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
                context.Users.Add(new User
                {
                    Login = "Azat"
                });

                context.Users.Add(new User
                {
                    Login = "Galym"
                });
                context.SaveChanges();
            }


        }
    }
}
