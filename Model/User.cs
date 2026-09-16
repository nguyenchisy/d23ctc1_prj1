using System;

namespace prj1.Model
{
    public class User
    {
        private string _username;
        private string _password;
        private string _role;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public string Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }

        public User(string username, string password, string role = "User")
        {
            _username = username;
            _password = password;
            _role = role;
        }
    }
}

