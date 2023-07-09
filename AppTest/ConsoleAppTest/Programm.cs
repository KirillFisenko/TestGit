using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;

public class MainClass
{
	public static void Main()
	{
		var n = Console.ReadLine();
		var ballsColor = Console.ReadLine().Split().ToList();
		var stack = new Stack<string>();
		var kills = 0;
		var currentColor = ballsColor[0];
		ballsColor.RemoveAt(0);
		stack.Push(currentColor);
		var cnt = 1;
		foreach (var collor in ballsColor)
		{

			if (collor == stack.Peek())
			{
				cnt++;
			}
			else
			{
				if(cnt >= 3)
				{
					kills += cnt;					
					for (var i = 0; i < cnt; i++)
					{
						stack.Pop();
					}
					cnt = 1;					
				}
				if(stack.Count > 0)
				{
					if (collor == stack.Peek())
					{
						cnt++;
					}
				}
			}

			stack.Push(collor);
		}


		Console.WriteLine(kills);
	}
}