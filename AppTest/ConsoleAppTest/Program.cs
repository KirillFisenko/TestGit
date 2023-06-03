using System;

public class MainClass
{
    public static void Main()
    {
        var inputLine = Console.ReadLine();

        char[] array = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '+', '-', '*', '/', '.', ',', ';', ':', ' ', };
        var transformLine = inputLine
                            .ToLower()
                            .Split(array, StringSplitOptions.RemoveEmptyEntries)
                            .OrderByDescending(x => x.Length)
                            .ThenBy(x => x);

        var outputResult = transformLine;
        foreach (var item in transformLine)
        {
            Console.WriteLine(item);
        }
    }
}