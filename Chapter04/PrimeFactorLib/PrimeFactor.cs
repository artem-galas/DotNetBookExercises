using System;
using System.Collections.Generic;

namespace PrimeFactorLib
{
    public class PrimeFactor
    {
        public static List<int> Calculate(int number)
        {
            var result = new List<int>();
            for (var pf = 2; number > 1; pf++)
            {
                while (number % pf == 0)
                {
                    number /= pf;
                    result.Add(pf);
                }
            }
            return result;
        } 
    }
}
