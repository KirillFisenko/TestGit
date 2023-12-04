public class User
{
    public string Name { get; set; }
    public int Age { get; set; }

    public bool IsAdalt(int age)
    {
        return age >= 18;
    }
}
public class MainClass
{
    public static void Main()
    {
      
        
    }

    public int CharCount(string s)
    {
        return s.Length;
    } 


}