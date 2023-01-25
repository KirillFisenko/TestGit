using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestGitConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Split();

            int n = Convert.ToInt32(s[0]);
            int k = Convert.ToInt32(s[1]) - 1;

            int[,] matrix = new int[n,n];

            for (int i = 0; i < n; i++)
            {
                string[] massive = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    matrix[i,j] = Convert.ToInt32(massive[j]);
                }
            }

            int countCalls = 0;
            int numberPerson = 0;

            for (int i = 0; i < n; i++)
            {                
                for (int j = 0; j < n; j++)
                {
                    if(matrix[i, k] > countCalls)
                    {
                        countCalls = matrix[i, j];
                        numberPerson = i + 1;
                    }
                }
            }

            Console.WriteLine(numberPerson);
        }
    }
}
