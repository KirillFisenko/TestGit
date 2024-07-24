using System;

public class MainClass
{
    public static void Main()
    {
        static void Main()
        {
            var number = Console.ReadLine().Select(char.GetNumericValue).OrderBy(x => x).ToArray();            
            var minDigit = number[0];
            var avgDigit = number[1];
            var maxDigit = number[2];
            Console.WriteLine(maxDigit - minDigit == avgDigit ? "Числов ыуинтересное" : "Число неинтересное2");
            //1
            //2
            //сделал изменение 1
            //сделал изменение 2
            //сделал изменение 3
        }
    }
}