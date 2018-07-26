using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Users
{
    public enum Role
    {
        user,
        admin
    }

    public class User
    {
        public int Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public Role UserRole { get; set; }

        public User() { }

        public User (string userLogin, string userPassword)
        {
            Login = userLogin;
            Password = Encoding.Default.GetString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(userPassword)));
        }

        public User(int id, string userLogin, string userPassword, Role role)
        {
            Id = id;
            Login = userLogin;
            Password = Encoding.Default.GetString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(userPassword)));
            UserRole = role;
        }
        
        public void SetUserData(int id, string userLogin, string userPassword, Role role)
        {
            Id = id;
            Login = userLogin;
            Password = userPassword;
            UserRole = role;
        }
        /*public bool EqualPass(string compPass)
        {
            return MD5.Equals(_password, MD5.Create().ComputeHash(Encoding.Default.GetBytes(compPass)));
        }*/

        /*public override bool Equals(object obj)
        {
            bool isEqual = false;
            if ((obj is User) & (obj != null))
            {
                User temp = (User)obj;
                if ((this.Login == temp.Login) && (MD5.Equals(this.Password, temp.Password)))
                    isEqual = true;
            }
            return isEqual;
        }*/
    }
}
