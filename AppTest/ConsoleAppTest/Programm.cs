using System;
using System.Collections.Generic;
using System.Linq;
public class MainClass
{
	public static void Main()
	{
		var availableAccessesPath = new List<string>();

		var N = int.Parse(Console.ReadLine());
		for (int i = 0; i < N; i++)
		{
			var availableAccessPath = Console.ReadLine();
			availableAccessesPath.Add(availableAccessPath);
		}

		var M = int.Parse(Console.ReadLine());
		for (int i = 0; i < M; i++)
		{
			var userRequestPath = Console.ReadLine();

			else
			{
				Console.WriteLine(availableAccessesPath.Any(
				path => path.Split('/')
				.ToHashSet()
				.IsSubsetOf(userRequestPath.Split('/').ToHashSet())
				) ? "YES" : "NO");
			}			
		}
	}
}