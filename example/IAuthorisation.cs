using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    interface IAuthorisation
    {
        bool IsAuthorised(User user);
        bool IsRegistration(User user);
    }
}
