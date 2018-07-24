using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace example
{
    enum Role { admin, user }
    class User
    {
        public int ID { get; private set; }
        public string Login { get; set; }
        private MD5 Password;
        public Role UserRole { get; private set; }
    }
}
