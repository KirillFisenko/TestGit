using System;
using System.Linq;
using System.Collections.Generic;

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
        SelectionSort(students);
        for (int i = students.Length - 1; i > students.Length - 4; i--)
        {
            Console.WriteLine(students[i].Name);
        }
    }

    static void SelectionSort(Student[] array)
    {
        for (int i = array.Length - 1; i > array.Length - 4; i--) // на какое место будем ставим наибольший элемент
        {
            int maxIndex = i; // индекс максимального элемента
            for (int j = 0; j < i; j++) // проходим по не отсортированной последовательности
            {
                if (array[j].Score > array[maxIndex].Score)// ищем максимальный элемент
                {
                    maxIndex = j; // запоминаем индекс
                }
            }

            // если нашли максимальный элемент, отличный от текущего числа
            if (maxIndex != i)
            {
                // меняем местами
                var temp = array[maxIndex];
                array[maxIndex] = array[i];
                array[i] = temp;
            }
        }
    }​
}