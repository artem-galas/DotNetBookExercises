using System;

namespace Exercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number between 0 and 255: ");
            try
            {
                int firstNumber = int.Parse(Console.ReadLine());
                Console.Write("Enter a second number between 0 and 255: ");
                int secondNumber = int.Parse(Console.ReadLine());

                if (firstNumber < 0 || firstNumber > 255)
                {
                    throw new ArgumentException($"{nameof(firstNumber)} must be lower than 255 and bigger than 0.");
                }
                if (secondNumber < 0 || secondNumber > 255)
                {
                    throw new ArgumentException($"{nameof(secondNumber)} must be lower than 255 and bigger than 0.");
                }
                int result = firstNumber / secondNumber;
                Console.WriteLine($"{firstNumber} / {secondNumber} = {result}");
            }
            catch(FormatException) {
                Console.WriteLine($"Input string shold be a number, try 10");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType()} {ex.Message}");
            }
        }
    }
}
