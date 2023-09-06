using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamax.Application.Models.Authenticaiton
{
    public class LoginResponse
    {
        public bool isSuccessful { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
    }
}
