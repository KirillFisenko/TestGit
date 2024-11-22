::c#
::code

/// <summary>
/// Получение общего количества пользователей
/// </summary>
public static int GetTotalCount()
{
    using var connection = new MySqlConnection(Constant.ConnectionString);
    connection.Open();

    var query = "SELECT COUNT(*) FROM users;";

    using var command = new MySqlCommand(query, connection);
    var result = command.ExecuteScalar();

    return result != null ? Convert.ToInt32(result) : 0;
}

::header
using System;
using System.Collections.Generic;



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
    public static bool WasExecuteScalarCalled = false;
    public new MySqlParameter Parameters { get; } = new MySqlParameter("", "");
    public string CommandText { get; internal set; }
    public MySqlCommand(string cmdText, MySqlConnection connection) { }

    public int ExecuteNonQuery()
    {
        WasExecuteNonQueryCalled = true;
        return 1;
    }

    public object ExecuteScalar()
    {
        WasExecuteScalarCalled = true;
        return 10;
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

public class UsersService
{
    ::footer


    public class Program
    {
        public static void Main()
        {
            UsersService.GetTotalCount();
            Console.WriteLine(MySqlConnection.WasDisposeCalled);
            Console.WriteLine(MySqlConnection.WasOpenCalled);
            Console.WriteLine(MySqlCommand.WasDisposeCalled);
            Console.WriteLine(MySqlCommand.WasExecuteScalarCalled);
        }
    }
}