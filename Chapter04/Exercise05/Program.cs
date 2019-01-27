using System;
using System.Collections.Generic;
using PrimeFactorLib;

namespace Exercise05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please add a number: ");
            if (int.TryParse(Console.ReadLine(), out int number)) {
                List<int> value = PrimeFactor.Calculate(number);
                string s = String.Join("*", value);
                Console.WriteLine($"Prime Factor for {number} = {s}");
            } else {
                Console.WriteLine("You add is not a number");
            }
        }
    }
}
