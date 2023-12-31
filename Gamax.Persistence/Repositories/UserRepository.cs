﻿using Gamax.Application.Contracts.Persistence;
using Gamax.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamax.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
