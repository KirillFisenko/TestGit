using System;
using System.Collections;

namespace CSharpEssentials
{
    public static void Main()
    {
        var ticketCost = int.Parse(Console.ReadLine());
        var windowSeatCost = int.Parse(Console.ReadLine());
        var food = int.Parse(Console.ReadLine());
        var m = int.Parse(Console.ReadLine());

        if(m <= 3)
        {
            m = 0;
        }
        else
        {
            m = 200 * (m - 3);
        }
        
        var result = ticketCost + windowSeatCost + food + m;
        Console.WriteLine($"Полёт обойдётся в {result} рублей");
    }
}