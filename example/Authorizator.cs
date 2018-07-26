using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure;
using System.IO;
using System.Security.Cryptography;

namespace Users
{
    class Authorizator : IAuthorization
    {
        private const string _userDataPath = "userDB.dat";

        private int _lastUserId;
        private Bidirectionallist<User> _userList = new Bidirectionallist<User>();

        public int UserCount
        {
            get { return _userList.Count; }
        }

        public Authorizator()
        {
            ReadUserData();
        }

        public User Authorization(string userLogin, string userPassword)
        {
            User locUser = null;
            foreach (var user in _userList)
            {
                if (user.Login == userLogin)
                {
                    if (Object.Equals(user.Password, Encoding.Default.GetString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(userPassword)))))
                    {
                        locUser = user;
                    }
                }
            }
            if (locUser == null)
                throw new Exception("Incorrect login or password!");
            return locUser;
        }

        public void Registration(string userLogin, string userPassword)
        {
            bool flagExistLogin = false;
            foreach (var user in _userList)
            {
                if (user.Login == userLogin)
                {
                    flagExistLogin = true;
                }
            }
            if (flagExistLogin)
                throw new Exception("User with such login is already registered!");
            else
            {
                User newUser = new User(++_lastUserId, userLogin, userPassword, Role.admin);
                _userList.PushHead(newUser);
                SaveUserList();
            }
        }

        public void SetAdmin(string adminLogin)
        {
            //now it is empty method
        }

        public void AddUser(User user)
        {
            _userList.PushTail(user);
        }
 
        public bool ReadUserData()
        {
            try
            {
                ReadUserDataFromfile();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void SaveUserList()
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(_userDataPath, FileMode.Create)))
                {
                    foreach (var elem in this._userList)
                    {
                        writer.Write(elem.Id);
                        writer.Write(elem.Login);
                        writer.Write(elem.Password);
                        writer.Write((int)elem.UserRole);
                    }
                }
            }
            catch
            {

            }
        }

        private void ReadUserDataFromfile()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(_userDataPath, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    int id = reader.ReadInt32();
                    string uLogin = reader.ReadString();
                    string uPass = reader.ReadString();
                    int role = reader.ReadInt32();
                    User u = new User();
                    u.SetUserData(id, uLogin, uPass, (Role)role);
                    this.AddUser(u);
                }
            }
            if (this.UserCount > 0)
                _lastUserId = this._userList.FindElementInd(_userList.Count - 1).Id;
            else
                _lastUserId = 0;
        }
    }
}
