using System;
using System.Linq;

namespace LINQ
{
    static class Program
    {
        static void Main()
        {
            var number = Console.ReadLine().Select(char.GetNumericValue).OrderBy(x => x).ToArray();            
            var minDigit = number[0];
            var avgDigit = number[1];
            var maxDigit = number[2];
            Console.WriteLine(maxDigit - minDigit == avgDigit ? "Число интересное" : "Число неинтересное");
        }
    }
}