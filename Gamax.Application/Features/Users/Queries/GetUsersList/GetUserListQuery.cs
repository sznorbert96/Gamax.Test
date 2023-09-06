using Gamax.Application.Features.Users.Queries.GetUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamax.Application.Features.Users.Queries.GetUsersList
{
    public class GetUserListQuery : IRequest<List<UserListVm>>
    {
    }
}
