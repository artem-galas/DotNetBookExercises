using System;
using System.Text.RegularExpressions;

namespace Exercice07
{
    class Program
    {
        static void Main(string[] args)
        {
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                var defaultPattern = new Regex(@"^[a-z]+$");
                var pattern = defaultPattern;

                Console.Write($"Enter a regular exeption or use default {defaultPattern}: ");
                var userPattern = Console.ReadLine();

                if (!String.IsNullOrEmpty(userPattern))
                {
                    pattern = new Regex($@"{userPattern}");
                }

                Console.Write("Enter some inputs: ");
                var userInput = Console.ReadLine();
                var isMatch = pattern.IsMatch(userInput);

                Console.WriteLine($"{userInput} mathces to {pattern}: {isMatch}");
                Console.WriteLine("Press ESC to end or any key to try again");
            }
        }
    }
}
