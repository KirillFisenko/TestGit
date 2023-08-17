using System;
using System.Collections.Generic;
using System.Linq;

public class MainClass
{
	public static void Main()
	{
		var inputLine = Console.ReadLine().Split().ToList();
		inputLine.ForEach(x => Console.WriteLine(x.Reverse()));
	}	
}