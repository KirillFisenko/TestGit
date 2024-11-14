//::c#
//::code
public class UsersService
{
    /// <summary>
    /// Добавление нового пользователя в таблицу users
    /// </summary>
    /// <param name="user">Новый пользователь</param>
    /// <returns>Удалось ли добавить пользователя</returns>
    public static bool Add(User user)
    {
        try
        {
            using var connection = new MySqlConnection(Constant.ConnectionString);
            connection.Open();
            var query = @"
                INSERT INTO users (full_name, details, join_date, avatar, is_active)
                VALUES (@FullName, @Details, @JoinDate, @Avatar, @IsActive)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@FullName", user.FullName);
            command.Parameters.AddWithValue("@Details", user.Details);
            command.Parameters.AddWithValue("@JoinDate", user.JoinDate);
            command.Parameters.AddWithValue("@Avatar", user.Avatar);
            command.Parameters.AddWithValue("@IsActive", user.IsActive);
            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected == 1;
        }
        catch
        {
            return false;
        }
    }
}

//::header
//using System;
//using System.Collections.Generic;


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

public class MySqlParameter
{
    public static int AddWithValueCountCalled;
    public static int nullCount;
    public MySqlParameter(string parameterName, object value) { }
    public void AddWithValue(string parameterName, object value)
    {
        if (value == null)
        {
            nullCount++;
        }

        if (parameterName.StartsWith("@"))
        {
            AddWithValueCountCalled++;
        }

        if (nullCount >= 3)
        {
            throw new Exception();
        }
    }
}

public class MySqlCommand : IDisposable
{
    public static bool WasExecuteNonQueryCalled = false;
    public static bool WasDisposeCalled = false;
    public new MySqlParameter Parameters { get; } = new MySqlParameter("", "");
    public string CommandText { get; internal set; }
    public MySqlCommand(string cmdText, MySqlConnection connection) { }

    public int ExecuteNonQuery()
    {
        WasExecuteNonQueryCalled = true;
        return 1;
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
    private static void Main(string[] args)
    {
        var newUser = new User()
        {
            FullName = "userName"
        };

        var result = UsersService.Add(newUser);
        Console.WriteLine(result);
        Console.WriteLine(MySqlConnection.WasOpenCalled);
        Console.WriteLine(MySqlConnection.WasDisposeCalled);
        Console.WriteLine(MySqlParameter.AddWithValueCountCalled == 5);
        Console.WriteLine(MySqlCommand.WasExecuteNonQueryCalled);
        Console.WriteLine(MySqlCommand.WasDisposeCalled);

        var user = new User
        {
            FullName = null,
            Details = null,
            Avatar = null,
        };
        result = UsersService.Add(newUser);
        Console.WriteLine(!result);
    }
}