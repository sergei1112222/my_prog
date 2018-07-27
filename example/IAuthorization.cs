using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public enum Role
    {
        User,
        Admin
    }

    public class User
    {
        public int Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public Role UserRole { get; set; }

        public User() { }

        public User(int id, string userLogin, string userPassword, Role role)
        {
            Id = id;
            Login = userLogin;
            Password = userPassword;
            UserRole = role;
        }
    }
    s
    public interface IAuthorization
    {
        User Authorize(string userLogin, string userPassword);
        void Registrate(string userLogin, string userPassword);
        void SetAdmin(string adminLogin);
    }
}
