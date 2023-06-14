using System;
using System.Linq;

public class Main
{
    public static void Mainn()
    {
        var text = Console.ReadLine().Split();        
        Console.WriteLine(text.Sum(word => word.Length));
    }
}