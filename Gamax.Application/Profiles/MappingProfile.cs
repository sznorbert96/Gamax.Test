using AutoMapper;
using Gamax.Application.Features.Users.Command.CreateUser;
using Gamax.Application.Features.Users.Command.UpdateUser;
using Gamax.Application.Features.Users.Queries.GetUser;
using Gamax.Application.Features.Users.Queries.GetUsersList;
using Gamax.Domain.Entities;

namespace Gamax.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, GetUserDto>().ReverseMap();
            CreateMap<User, UserListVm>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
        }
    }
}
