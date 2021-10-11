﻿using System;
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
                Regex regx = new Regex(@"^[a-zA-Z ]+$");
                if (!regx.IsMatch(userFirstName) || userFirstName.Length < 3 || userFirstName.Length > 20)
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
                Regex regx = new Regex(@"^[a-zA-Z ]+$");
                if (!regx.IsMatch(userLastName) || userLastName.Length < 3 || userLastName.Length > 20)
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
        }
    }
}
