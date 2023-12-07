public class User
{
    public string Name { get; set; }
    public int Age { get; set; }

    public bool IsAdalt(int age)
    {
        return age >= 18;
    }
}

public class Program
{
    static void Main()
    {

    }
}