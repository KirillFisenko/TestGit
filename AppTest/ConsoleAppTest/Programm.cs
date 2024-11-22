::c#
::code
public class Course
{
    public string Title { get; set; }
    public string? Summary { get; set; }
    public string? Photo { get; set; }
}

::header
using System;

namespace Sandbox
{
    internal class Program
    {

        //::footer
        private static void Main(string[] args)
        {
            var newCourse = new Course()
            {
                Title = "Title"
            };
            Console.WriteLine(newCourse.Title == "Title");
            Console.WriteLine(newCourse.Summary == null);
            Console.WriteLine(newCourse.Photo == null);

            newCourse = new Course()
            {
                Title = "Title",
                Summary = "Summary",
                Photo = "Photo",
            };
            Console.WriteLine(newCourse.Title == "Title");
            Console.WriteLine(newCourse.Summary == "Summary");
            Console.WriteLine(newCourse.Photo == "Photo");
        }
    }
}



