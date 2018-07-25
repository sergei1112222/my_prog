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
        admin,
        user
    }

    public class User
    {

        public byte[] _password { get; private set; }

        public int Id { get; private set; }
        public string Login { get; private set; }
        
        public Role UserRole { get; set; }


        public User() { }

        public User (string userLogin, string userPassword)
        {
            this.Login = userLogin;
            this._password = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(userPassword));
        }
        public User(int id, string userLogin, byte[] userPassword, int role)
        {
            this.Id = id;
            this.Login = userLogin;
            this._password = userPassword;
            this.UserRole = (Role)role;
        }

        /*public bool EqualPass(string compPass)
        {
            return MD5.Equals(_password, MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(compPass)));
        }*/

        public override bool Equals(object obj)
        {
            bool isEqual = false;
            if ((obj is User) & (obj != null))
            {
                User temp = (User)obj;
                if ((this.Login == temp.Login) && (MD5.Equals(this._password, temp._password)))
                    isEqual = true;
            }
            return isEqual;
        }
    }
}
