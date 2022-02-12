using System;
using System.Globalization;
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
            Console.WriteLine("Please type in your first name and press ENTER to submit or type Quit to exit.");
            var userFirstNameCorrect = false;
            while (!userFirstNameCorrect)
            {
                userFirstName = Console.ReadLine();
                var userFirstNameRegex = new Regex(@"^(?!\s)[a-zA-Z ]+$");
                if (userFirstName.ToUpper().Equals("QUIT"))
                {
                    Console.WriteLine("Thanks for typing ‘QUIT’, exiting!");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
                else if (!userFirstNameRegex.IsMatch(userFirstName) || userFirstName.Length < 3 || userFirstName.Length > 20)
                {
                    Console.WriteLine("Your first name must be between 3-20 characters and can only contain letters and spaces. Please try again.");
                }
                else
                {
                    userFirstNameCorrect = true;
                }
            }
            Console.WriteLine("Please type in your last name and press ENTER to submit or type Quit to exit.");
            var userLastNameCorrect = false;
            while (!userLastNameCorrect)
            {
                userLastName = Console.ReadLine();
                var userLastNameRegex = new Regex(@"^(?!\s)[a-zA-Z ]+$");
                if (userLastName.ToUpper().Equals("QUIT"))
                {
                    Console.WriteLine("Thanks for typing ‘QUIT’, exiting!");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
                else if(!userLastNameRegex.IsMatch(userLastName) || userLastName.Length < 3 || userLastName.Length > 20)
                {
                    Console.WriteLine("Your last name must be between 3-20 characters and can only contain letters and spaces. Please try again.");
                }
                else
                {
                    userLastNameCorrect = true;
                }

            }
            Console.WriteLine("Please type in your ID number and press ENTER to submit or type Quit to exit.");
            var userIdNumberCorrect = false;
            while (!userIdNumberCorrect)
            {
                userIdNumber = Console.ReadLine();
                var userIdNumberRegex = new Regex(@"^[0-9]+$");
                if (userIdNumber.ToUpper().Equals("QUIT"))
                {
                    Console.WriteLine("Thanks for typing ‘QUIT’, exiting!");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                }
                else if (!userIdNumberRegex.IsMatch(userIdNumber) || userIdNumber.Length != 13)
                {
                    Console.WriteLine("Your ID number must be 13 characters and can only contain numbers. Please try again.");
                }
                else
                {
                    userIdNumberCorrect = true;
                }

            }

            using (var createRandomTextFile = new FileStream(Path.GetFileNameWithoutExtension(Path.GetRandomFileName())+".txt", FileMode.Create))

            using (var writeToRandomTextFile = new StreamWriter(createRandomTextFile))
            {
                var year = int.Parse(userIdNumber.Substring(0, 2));
                var month = userIdNumber.Substring(2, 2);
                var day = userIdNumber.Substring(4, 2);
                var fourDigitYear = CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(year);
                writeToRandomTextFile.WriteLine("User ID: " + new Random().Next(10000, 99999));
                writeToRandomTextFile.WriteLine("First Name: " + userFirstName);
                writeToRandomTextFile.WriteLine("Last Name: " + userLastName);

                DateTime dateOfbirth;
                if (DateTime.TryParse($"{fourDigitYear}-{month}-{day}", out dateOfbirth))
                {
                    writeToRandomTextFile.WriteLine("Date of Birth: " + $"{day}-{month}-{fourDigitYear}");
                }
                else
                {
                    writeToRandomTextFile.WriteLine("Date of Birth: " + $"Invalid date entered: " + userIdNumber.Substring(0,6));
                }
            }
        }
    }
}

