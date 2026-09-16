using System;

namespace prj1.Model
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "User";

        public User(string username, string password, string role = "User")
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}

