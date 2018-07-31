using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonNotebook.Common;
using System.IO;
using System.Security.Cryptography;

namespace PersonNotebook.Authorization.Authorizator
{
    class Authorizator : IAuthorization
    {
        private const string _userDataPath = "userDB.dat";

        private int _lastUserId;
        private Bidirectionallist<User> _userList = new Bidirectionallist<User>();
        public int UserCount { get { return _userList.Count; } }

        public Authorizator()
        {
            ReadUserData();
        }

        public User Authorize(string userLogin, string userPassword)
        {
            string locHash = getMD5(userPassword);
            User locUser = _userList.FirstOrDefault(user => user.Login == userLogin && user.Password == locHash);
            if (locUser == null)
                throw new Exception("Incorrect login or password!");
            return locUser;
        }

        public void Register(string userLogin, string userPassword, Role role)
        {
            User locUser = _userList.FirstOrDefault(user => user.Login == userLogin);
            if (locUser != null)
                throw new Exception("User with such login is already registered!");
            else
            {
                User newUser = new User(++_lastUserId, userLogin, getMD5(userPassword), role);
                _userList.PushTail(newUser);
                SaveUserList();
            }
        }

        public bool DeleteUser(int id)
        {
            User user = _userList.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                File.Delete(user.Login + "list.dat");
                _userList.RemoveRequest(_user => _user.Id == id, false);
                return true;
            }
            else
                return false;
        }

        public void SetAdmin(string adminLogin)
        {
            User user = _userList.FirstOrDefault(u => u.Login == adminLogin);
            if (user != null)
            {
                if (user.UserRole == Role.Admin)
                    throw new Exception("This login is admin yet!");
                else
                    user.UserRole = Role.Admin;
            }
            else
                throw new Exception("This login does not exist!");

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

        public Bidirectionallist<User> GetUserList()
        {
            return _userList;
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
                    this.AddUser(new User(id, uLogin, uPass, (Role)role));
                }
            }
            if (this.UserCount > 0)
                _lastUserId = this._userList.FindElementInd(_userList.Count - 1).Id;
            else
                _lastUserId = 0;
        }

        private string getMD5(string inputString)
        {
            return Encoding.Default.GetString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(inputString)));
        }
    }
}
