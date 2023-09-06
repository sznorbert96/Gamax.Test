using Gamax.Application.Contracts.Persistence;
using Gamax.Identity.Contracts.Identity;
using Gamax.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamax.Identity.Services.Identity
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserManagementDbContext _dbContext;

        public UserAuthenticationService(UserManagementDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public string AuthenticateUser(string email, string password)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == email && x.Password == password);

            if(user != null)
            {
                return user.UserId.ToString();
            }
            
            return string.Empty;
        }
    }
}
