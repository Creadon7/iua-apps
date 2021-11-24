using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace UserDetails
{
    class Program
    {
        private static string userFirstName;
        private static string userLastName;
        private static string userIdNumber;

        static void Main(string[] args)
        {
            Console.WriteLine("Please type in your first name and press ENTER?");
            var userFirstNameCorrect = false;
            while (!userFirstNameCorrect)
            {
                userFirstName = Console.ReadLine();
                var regx = new Regex(@"^(?!\s)[a-zA-Z ]+$");
                if (userFirstName.ToUpper().Equals("QUIT"))
                {
                    Console.WriteLine("Thanks for typing ‘QUIT’, exiting!");
                    Thread.Sleep(3000);
                    return;
                }
                else if (!regx.IsMatch(userFirstName) || userFirstName.Length < 3 || userFirstName.Length > 20)
                {
                    Console.WriteLine("Your first name must be between 3-20 characters and can only contain letters and spaces. Please try again.");
                }
                else if (regx.IsMatch(userFirstName) && userFirstName.Length >= 3 && userFirstName.Length <= 20)
                {
                    userFirstNameCorrect = true;
                }
                else
                {
                    Console.WriteLine("We didn't understand. Please try again.");
                }
            }
            Console.WriteLine("Please type in your last name and press ENTER?");
            var userLastNameCorrect = false;
            while (!userLastNameCorrect)
            {
                userLastName = Console.ReadLine();
                var regx = new Regex(@"^(?!\s)[a-zA-Z ]+$");
                if (userLastName.ToUpper().Equals("QUIT"))
                {
                    Console.WriteLine("Thanks for typing ‘QUIT’, exiting!");
                    Thread.Sleep(3000);
                    return;
                }
                else if(!regx.IsMatch(userLastName) || userLastName.Length < 3 || userLastName.Length > 20)
                {
                    Console.WriteLine("Your last name must be between 3-20 characters and can only contain letters and spaces. Please try again.");
                }
                else if (regx.IsMatch(userLastName) && userLastName.Length >= 3 && userLastName.Length <= 20)
                {
                    userLastNameCorrect = true;
                }
                else
                {
                    Console.WriteLine("We didn't understand. Please try again.");
                }
            }
            Console.WriteLine("Please type in your ID number and press ENTER?");
            var userIdNumberCorrect = false;
            while (!userIdNumberCorrect)
            {
                userIdNumber = Console.ReadLine();
                var regx = new Regex(@"^[0-9]+$");
                if (userIdNumber.ToUpper().Equals("QUIT"))
                {
                    Console.WriteLine("Thanks for typing ‘QUIT’, exiting!");
                    Thread.Sleep(3000);
                    return;
                }
                else if (!regx.IsMatch(userIdNumber) || userIdNumber.Length != 13)
                {
                    Console.WriteLine("Your ID number must be 13 characters and can only contain numbers. Please try again.");
                }
                else if (regx.IsMatch(userIdNumber) && userIdNumber.Length == 13)
                {
                    userIdNumberCorrect = true;
                }
                else
                {
                    Console.WriteLine("We didn't understand. Please try again.");
                }
            }

            using (var fileStream = new FileStream(Path.GetFileNameWithoutExtension(Path.GetRandomFileName())+".txt", FileMode.Create))

            using (var streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine("User ID: " + new Random().Next(10000, 99999));
                streamWriter.WriteLine("First Name: " + userFirstName);
                streamWriter.WriteLine("Last Name: " + userLastName);
                streamWriter.WriteLine("Date of Birth: " );
            }
        }
    }
}

