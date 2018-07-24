using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example
{
    interface IAuthorisation
    {
        bool IsAuthorised(string login, string passwors);
        bool IsRegistration(string login, string password);

    }
}
