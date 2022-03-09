using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace UserDetails
{
    class Program
    {
        private static RequestResult GetInput(string fieldName, string validationRegEx, string validationMessage)
        {
            InputManager inputManager = new InputManager();
            RequestResult result = inputManager.RequestInput(fieldName, validationRegEx, validationMessage);
            if (result.ResultType == RequestResultType.UserQuit)
            {
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            return result;
        }

        static void Main(string[] args)
        {


            RequestResult userFirstNameResult = GetInput("first name", @"^(?!\s)[a-zA-Z ]+$", "Please enter a valid first name, minimum length 3 characters, maximum 20");
            RequestResult userLastNameResult = GetInput("last name", @"^(?!\s)[a-zA-Z ]+$", "Please enter a valid last name, minimum length 3 characters, maximum 20");
            RequestResult idNumberResult = GetInput("id number", @"^[0-9]+$", "Please enter a valid ID number, this must be 13 digits");

            using (var createRandomTextFile = new FileStream(Path.GetFileNameWithoutExtension(Path.GetRandomFileName())+".txt", FileMode.Create))

            using (var writeToRandomTextFile = new StreamWriter(createRandomTextFile))
            {
                string userIdNumber = idNumberResult.Text;

                var year = int.Parse(userIdNumber.Substring(0, 2));
                var month = userIdNumber.Substring(2, 2);
                var day = userIdNumber.Substring(4, 2);
                var fourDigitYear = CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(year);
                writeToRandomTextFile.WriteLine("User ID: " + new Random().Next(10000, 99999));
                writeToRandomTextFile.WriteLine("First Name: " + userFirstNameResult.Text);
                writeToRandomTextFile.WriteLine("Last Name: " + userLastNameResult.Text);

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

