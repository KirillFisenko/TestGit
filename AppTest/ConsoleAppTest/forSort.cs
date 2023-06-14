using System;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public double Score { get; set; }
    public Student(string name, double score)
    {
        Name = name;
        Score = score;
    }
}
public class MainClass
{
    public static void Main()
    {
        var N = int.Parse(Console.ReadLine());
        var students = new Student[N];
        for (int i = 0; i < N; i++)
        {
            var line = Console.ReadLine().Split();
            var name = string.Join(" ", line.Take(2));
            var score = int.Parse(line[2]);
            var student = new Student(name, score);
            students[i] = student;
        }
        BubbleSort(students);
        for (int i = students.Length - 1; i > students.Length - 4; i--)
        {
            Console.WriteLine(students[i].Name);
        }
    }

    static void BubbleSort(Student[] array)
    {
        for (var i = array.Length - 1; i > array.Length - 4; i--)
        {
            var flag = false;
            for (var j = 0; j < i; j++)
            {
                if (array[j].Score > array[j + 1].Score)
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    flag = true;
                }
            }
            if (!flag)
            {
                return;
            }
        }
    }
}
