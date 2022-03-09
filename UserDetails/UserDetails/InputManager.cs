using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace UserDetails
{
    internal class InputManager
    {

        public RequestResult RequestInput(string fieldName, string validationRegEx, string validationMessage)
        {

            Console.WriteLine("Please type in your " + fieldName + " and press ENTER to submit or type Quit to exit.");

            string inputText = Console.ReadLine();

            var inputRegex = new Regex(validationRegEx);
            if (inputText.ToUpper().Equals("QUIT"))
            {
                Console.WriteLine("Thanks for typing ‘QUIT’, exiting!");
                return new RequestResult(RequestResultType.UserQuit, null);
            }
            else if (!inputRegex.IsMatch(inputText) || inputText.Length < 3 || inputText.Length > 20)
            {
                Console.WriteLine(validationMessage);
                return this.RequestInput(fieldName, validationRegEx, validationMessage);
            }

            return new RequestResult(RequestResultType.ValidEntry, inputText); ;
        }
    }
}
