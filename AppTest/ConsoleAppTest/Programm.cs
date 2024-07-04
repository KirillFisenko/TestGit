using System;

public class MainClass
{
    public static void Main()
    {
        var inputString = Console.ReadLine().Split(", ");
        var resultHashSet = inputString.ToHashSet();
        Console.WriteLine(string.Join(", ", resultHashSet));
    }
}