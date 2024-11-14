//::c#
//::code
public class User
{
    public string FullName { get; set; }
    public string? Details { get; set; }
    public DateTime JoinDate { get; set; } = DateTime.Now;
    public string? Avatar { get; set; }
    public bool IsActive { get; set; } = true;
}

//::header
//using System;

namespace Sandbox
{
    internal class Program
    {

        //::footer
        private static void Main(string[] args)
        {
            var newUser = new User()
            {
                FullName = "userName"
            };
            Console.WriteLine(newUser.FullName == "userName");
            Console.WriteLine(newUser.Details == null);
            Console.WriteLine(!string.IsNullOrWhiteSpace(newUser.JoinDate.ToString()));
            Console.WriteLine(newUser.Avatar == null);
            Console.WriteLine(newUser.IsActive);

            newUser = new User()
            {
                FullName = "userName",
                Details = "Details",
                JoinDate = DateTime.Now.Date,
                Avatar = "Avatar",
                IsActive = false
            };
            Console.WriteLine(newUser.FullName == "userName");
            Console.WriteLine(newUser.Details == "Details");
            Console.WriteLine(newUser.JoinDate == DateTime.Now.Date);
            Console.WriteLine(newUser.Avatar == "Avatar");
            Console.WriteLine(newUser.IsActive == false);
        }
    }
}



