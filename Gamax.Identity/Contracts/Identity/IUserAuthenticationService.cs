using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamax.Identity.Contracts.Identity
{
    public interface IUserAuthenticationService
    {
        string AuthenticateUser(string email, string password);
    }
}
