//::c#
//::code

/// <summary>
/// Получение списка курсов пользователя
/// </summary>
/// <param name="fullName">Полное имя пользователя</param>
/// <returns>List<Course></returns>
public static List<Course> Get(string fullName)
{
    var courses = new List<Course>();

    using var connection = new MySqlConnection(Constant.ConnectionString);
    connection.Open();

    var query = @"
            SELECT title, summary, photo
            FROM user_courses
            JOIN courses ON user_courses.course_id = courses.id
            JOIN users ON users.id = user_courses.user_id
            WHERE users.full_name = @fullName AND users.is_active = 1
            ORDER BY user_courses.last_viewed DESC;";

    using var command = new MySqlCommand(query, connection);
    var fullNameParam = new MySqlParameter("@fullName", fullName);
    command.Parameters.Add(fullNameParam);

    using var reader = command.ExecuteReader();
    while (reader.Read())
    {
        var course = new Course
        {
            Title = reader.GetString(0),
            Summary = reader.IsDBNull(1) ? null : reader.GetString(1),
            Photo = reader.IsDBNull(2) ? null : reader.GetString(2)
        };
        courses.Add(course);
    }

    return courses;
}



//::header
//using System;
//using System.Reflection.PortableExecutable;
//using System.Collections.Generic;
//using System.Linq;
public class MySqlConnection : IDisposable
{
    public static bool WasOpenCalled = false;
    public static bool WasDisposeCalled = false;
    public MySqlConnection(string connectionString) { }

    public void Open()
    {
        WasOpenCalled = true;
    }
    public void Dispose()
    {
        WasDisposeCalled = true;
    }
}

public sealed class MySqlDataReader : IDisposable
{
    public bool read = false;
    public MySqlCommand Command { get; set; }

    public void Dispose() { }

    public bool GetBoolean(int v)
    {
        return true;
    }

    public DateTime GetDateTime(int v)
    {
        return DateTime.UtcNow;
    }

    public string GetString(int v)
    {
        return "";
    }

    public bool IsDBNull(int v)
    {
        return false;
    }

    public bool Read()
    {
        read = !read;
        return read;
    }
}

public class MySqlParameter
{
    public static int AddWithValueCountCalled;
    public static bool WasAddCalled = false;
    public MySqlParameter(string parameterName, object value) { }
    public void AddWithValue(string parameterName, object value)
    {
        if (parameterName.StartsWith("@"))
        {
            AddWithValueCountCalled++;
        }
    }

    public void Add(MySqlParameter fullNameParam)
    {
        WasAddCalled = true;
    }
}


public class MySqlCommand : IDisposable
{
    public static bool WasExecuteNonQueryCalled = false;
    public static bool WasDisposeCalled = false;
    public static bool WasExecuteReaderCalled = false;

    public new MySqlParameter Parameters { get; } = new MySqlParameter("", "");
    public string CommandText { get; internal set; }
    public MySqlCommand(string cmdText, MySqlConnection connection) { }

    public int ExecuteNonQuery()
    {
        WasExecuteNonQueryCalled = true;
        return 1;
    }

    public MySqlDataReader ExecuteReader()
    {
        WasExecuteReaderCalled = true;
        return new MySqlDataReader();
    }

    public void Dispose()
    {
        WasDisposeCalled = true;
    }
}

public class Constant
{
    public const string ConnectionString = "Server=localhost;Database=stepik;Uid=root;Pwd=;";
}


public class User
{
    public string FullName { get; set; }
    public string? Details { get; set; }
    public DateTime JoinDate { get; set; } = DateTime.Now;
    public string? Avatar { get; set; }
    public bool IsActive { get; set; } = true;
}

public class Course
{
    public string Title { get; set; }
    public string? Summary { get; set; }
    public string? Photo { get; set; }
}



public class Program
{
    public static void Main()
    {
        var result = CoursesService.Get("").FirstOrDefault();

        Console.WriteLine(string.IsNullOrEmpty(result.Title));
        Console.WriteLine(string.IsNullOrEmpty(result.Summary));
        Console.WriteLine(string.IsNullOrEmpty(result.Photo));

        Console.WriteLine(MySqlCommand.WasExecuteReaderCalled);
        Console.WriteLine(MySqlConnection.WasOpenCalled);
        Console.WriteLine(MySqlConnection.WasDisposeCalled);
        Console.WriteLine(MySqlCommand.WasDisposeCalled);
        Console.WriteLine(MySqlParameter.WasAddCalled);


    }
}

public class CoursesService
{
    //::footer



}