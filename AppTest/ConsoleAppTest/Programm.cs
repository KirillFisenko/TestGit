//::c#
//::code

public class UsersService
{
    /// <summary>
    /// Получение пользователя из таблицы users
    /// </summary>
    /// <param name="fullName">Полное имя пользлователя</param>
    /// <returns>User</returns>
    public static User Get(string fullName)
    {
        var user = new User();
        using var connection = new MySqlConnection(Constant.ConnectionString);
        connection.Open();
        var query = @"SELECT * FROM users
                      WHERE full_name = @FullName AND is_active = 1;";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@FullName", fullName);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            user.FullName = reader.IsDBNull(1) ? null : reader.GetString(1);
            user.Details = reader.IsDBNull(2) ? null : reader.GetString(2);
            user.JoinDate = reader.GetDateTime(3);
            user.Avatar = reader.IsDBNull(4) ? null : reader.GetString(4);
            user.IsActive = reader.GetBoolean(5);
        }

        return user;
    }
}

//::header
//using System;
//using System.Reflection.PortableExecutable;


//::footer

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
        return false;
    }
}

public class MySqlParameter
{
    public static int AddWithValueCountCalled;
    public MySqlParameter(string parameterName, object value) { }
    public void AddWithValue(string parameterName, object value)
    {
        if (parameterName.StartsWith("@"))
        {
            AddWithValueCountCalled++;
        }
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


public class Program
{
    public static void Main()
    {
        var result = UsersService.Get("");
        Console.WriteLine(string.IsNullOrEmpty(result.FullName));
        Console.WriteLine(string.IsNullOrEmpty(result.Details));
        Console.WriteLine(result.JoinDate.Date == DateTime.Today.Date);
        Console.WriteLine(string.IsNullOrEmpty(result.Avatar));
        Console.WriteLine(result.IsActive);

        Console.WriteLine(MySqlConnection.WasOpenCalled);
        Console.WriteLine(MySqlConnection.WasDisposeCalled);
        Console.WriteLine(MySqlCommand.WasDisposeCalled);
    }
}