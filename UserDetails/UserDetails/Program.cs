using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your first name?");
            bool userFirstNameCorrect = false;
            while (!userFirstNameCorrect)
            {
                string userFirstName = Console.ReadLine();
                Regex regx = new Regex(@"^(?!\s)[a-zA-Z ]+$");
                if (userFirstName.ToUpper().Equals("QUIT"))
                {
                    Console.WriteLine("Thanks for typing ‘QUIT’, exiting!");
                    System.Threading.Thread.Sleep(3000);
                    return;
                }
                else if (!regx.IsMatch(userFirstName) || userFirstName.Length < 3 || userFirstName.Length > 20)
                {
                    Console.WriteLine("Your first name must be between 3-20 characters and can only contain letters and spaces. Please try again.");
                }
                else if (regx.IsMatch(userFirstName) && userFirstName.Length >= 3 && userFirstName.Length <= 20)
                {
                    Console.WriteLine(userFirstName);
                    userFirstNameCorrect = true;
                }
                else
                {
                    Console.WriteLine("We didn't understand. Please try again.");
                }
            }
            Console.WriteLine("What is your last name?");
            bool userLastNameCorrect = false;
            while (!userLastNameCorrect)
            {
                string userLastName = Console.ReadLine();
                Regex regx = new Regex(@"^(?!\s)[a-zA-Z ]+$");
                if (userLastName.ToUpper().Equals("QUIT"))
                {
                    Console.WriteLine("Thanks for typing ‘QUIT’, exiting!");
                    System.Threading.Thread.Sleep(3000);
                    return;
                }
                else if(!regx.IsMatch(userLastName) || userLastName.Length < 3 || userLastName.Length > 20)
                {
                    Console.WriteLine("Your last name must be between 3-20 characters and can only contain letters and spaces. Please try again.");
                }
                else if (regx.IsMatch(userLastName) && userLastName.Length >= 3 && userLastName.Length <= 20)
                {
                    Console.WriteLine(userLastName);
                    userLastNameCorrect = true;
                }
                else
                {
                    Console.WriteLine("We didn't understand. Please try again.");
                }
            }
            Console.WriteLine("What is your ID number?");
            bool userIdNumberCorrect = false;
            while (!userIdNumberCorrect)
            {
                string userIdNumber = Console.ReadLine();
                Regex regx = new Regex(@"^[0-9]+$");
                if (userIdNumber.ToUpper().Equals("QUIT"))
                {
                    Console.WriteLine("Thanks for typing ‘QUIT’, exiting!");
                    System.Threading.Thread.Sleep(3000);
                    return;
                }
                else if (!regx.IsMatch(userIdNumber) || userIdNumber.Length != 13)
                {
                    Console.WriteLine("Your ID number must be 13 characters and can only contain numbers. Please try again.");
                }
                else if (regx.IsMatch(userIdNumber) && userIdNumber.Length == 13)
                {
                    Console.WriteLine(userIdNumber);
                    userIdNumberCorrect = true;
                }
                else
                {
                    Console.WriteLine("We didn't understand. Please try again.");
                }
            }
        }
    }
}

