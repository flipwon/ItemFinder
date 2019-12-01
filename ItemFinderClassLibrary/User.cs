using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemFinderClassLibrary
{
    class User
    {
        public int Id { get; }
        public string UserName { get; }
        public string Password { get; }
        public UserRole Role { get; }

        public User(int id, string userName, string password, UserRole role)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Role = role;
        }
    }

    enum UserRole
    {
        User,
        Admin
    }
}
