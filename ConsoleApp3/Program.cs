using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace ConsoleApp3
{
    class Program
    {        
        static void Main(string[] args)
        {
            User user = new User();
            while (true)
            {
                Console.WriteLine("Введите логин: ");
                user.Login = Console.ReadLine();
                if (user.Login.Contains("@") && user.Login.Contains("."))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильно введен логин: ");
                }
            }            
            Console.WriteLine("Введите пароль: ");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    user.Password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && user.Password.Length > 0)
                    {
                        user.Password = user.Password.Substring(0, (user.Password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            Console.WriteLine("Ваш введенный пароль : " + user.Password);

            Random random = new Random();
            string checkNumber = "";
            checkNumber += random.Next(1000, 10000);
            Console.WriteLine(checkNumber);

            // Find your Account Sid and Token at twilio.com/console
            const string accountSid = "ACb0ce4eebe9bc3e3552877e74f8b1c4dc";
            const string authToken = "5b099bd03e1e6c115edbb5faf75d5e49";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: checkNumber,
                from: new Twilio.Types.PhoneNumber("+17152278964"),
                to: new Twilio.Types.PhoneNumber("+77718879988")
            );

            Console.ReadKey();
        }
    }
}
