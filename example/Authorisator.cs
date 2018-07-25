using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure;
using System.IO;

namespace Users
{
    class Authorisator: IAuthorisation
    {
        private const string UserDataPATH = "userDB.dat";

        private int _lastIDUser;
        private Bidirectionallist<User> _userList = new Bidirectionallist<User>();

        public int UserCount
        {
            get { return _userList.Count; }
        }

        public Authorisator() { }

        public bool IsAuthorised(User user)
        {
            //Now it is empty method
            return false;
        }

        public bool IsRegistration(User user)
        {
            //Now it is empty method
            return false;
        }

        #region Methods for working with User
        public void AddUser(User user)
        {
            _userList.PushTail(user);
        }
        #endregion
        public bool ReadUserData()
        {
            readFromFile locReader = ReadUserDataFromfile;
            try
            {
                locReader();
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
                using (BinaryWriter writer = new BinaryWriter(File.Open(UserDataPATH, FileMode.Create)))
                {
                    foreach (var elem in this._userList)
                    {
                        writer.Write(elem.Id);
                        writer.Write(elem.Login);
                        writer.Write(elem._password.Length);
                        writer.Write(elem._password);
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
            using (BinaryReader reader = new BinaryReader(File.Open(UserDataPATH, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    int id = reader.ReadInt32();
                    string uLogin = reader.ReadString();
                    int hashSize = reader.ReadInt32();
                    byte[] uPass = reader.ReadBytes(hashSize);
                    int role = reader.ReadInt32();
                    User u = new User(id, uLogin, uPass, role);
                    this.AddUser(u);
                }
            }
            if (this.UserCount > 0)
                _lastIDUser = this._userList.FindElementInd(_userList.Count - 1).Id;
            else
                _lastIDUser = 0;
        }

        private delegate void readFromFile();
    }
}
