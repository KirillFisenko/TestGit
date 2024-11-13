::c#
::code


    public static void Main()
{
    // Обновить логику
}

public static void LoginUser()
{
    // Реализовать метод
}



::header
using System;
using System.Reflection.PortableExecutable;
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
public class UsersService
{
    public static List<string> users = new List<string>();
    /// <summary>
    /// Добавление нового пользователя в таблицу users
    /// </summary>
    /// <param name="user">Новый пользователь</param>
    /// <returns>Удалось ли добавить пользователя</returns>
    public static bool Add(User user)
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
        users.Add(user.FullName);
        return rowsAffected == 1;
    }

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

        user.FullName = fullName;
        user.Details = reader.IsDBNull(2) ? null : reader.GetString(2);
        user.JoinDate = reader.GetDateTime(3);
        user.Avatar = reader.IsDBNull(4) ? null : reader.GetString(4);
        user.IsActive = reader.GetBoolean(5);


        return users.Contains(fullName) ? user : new User();
    }
}

public class Program
{
::footer

        public static void RegisterUser()
    {
        Console.WriteLine("Введите имя и фамилию через пробел и нажмите Enter:");
        var userName = Console.ReadLine();
        var newUser = new User()
        {
            FullName = userName
        };

        var isAdditionSuccessful = UsersService.Add(newUser);

        if (isAdditionSuccessful)
        {
            Console.WriteLine($"Пользователь '{newUser.FullName}' успешно добавлен.\n");
        }
        else
        {
            Console.WriteLine($"Произошла ошибка, произведен выход на главную страницу\n");
        }
    }
}