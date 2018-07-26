using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    public interface IAuthorization
    {
        User Authorization(string userLogin, string userPassword);
        void Registration(string userLogin, string userPassword);
        void SetAdmin(string adminLogin);
    }
}
