using Gamax.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamax.Application.Features.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<GetUserDto>
    {
        public Guid UserId { get; set; }
    }
}
