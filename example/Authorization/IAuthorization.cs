using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structure;

namespace Users
{
    
    
    public interface IAuthorization
    {
        User Authorize(string userLogin, string userPassword);
        void Register(string userLogin, string userPassword, Role role);
        void SetAdmin(string adminLogin);
        Bidirectionallist<User> GetUserList();
        bool DeleteUser(int id);
    }
}
