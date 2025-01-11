::c#
::code

public class CommentsService
{
    /// <summary>
    /// Получение всех комментариев к курсу
    /// </summary>
    /// <param name="id">id курса</param>
    /// <returns>Список комментариев</returns>
    public static List<Comment> Get(int id)
    {
        // Реализовать метод
    }
}



::header
using System;
using System.Reflection.PortableExecutable;
using System.Collections.Generic;
using System.Linq;
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

public class MySqlDataReader : IDisposable
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

    public int GetInt32(int v)
    {
        return 1;
    }

    public bool GetBoolean(string v)
    {
        return true;
    }

    public DateTime GetDateTime(string v)
    {
        return DateTime.UtcNow;
    }

    public string GetString(string v)
    {
        return "";
    }

    public int GetInt32(string v)
    {
        return 1;
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

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime Time { get; set; }
}


public class Program
{
    public static void Main()
    {
        var result = CommentsService.Get(0).FirstOrDefault();

        Console.WriteLine(result.Id == 1);
        Console.WriteLine(string.IsNullOrEmpty(result.Text));
        Console.WriteLine(result.Time.Date == DateTime.UtcNow.Date);

        Console.WriteLine(MySqlCommand.WasExecuteReaderCalled);
        Console.WriteLine(MySqlConnection.WasOpenCalled);
        Console.WriteLine(MySqlConnection.WasDisposeCalled);
        Console.WriteLine(MySqlCommand.WasDisposeCalled);
        Console.WriteLine(MySqlParameter.WasAddCalled);
    }
}