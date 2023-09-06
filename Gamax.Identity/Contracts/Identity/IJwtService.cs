﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamax.Identity.Contracts.Identity
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string email);
    }
}
