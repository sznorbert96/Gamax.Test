using AutoMapper;
using Gamax.Application.Contracts.Persistence;
using Gamax.Application.Features.Users.Queries.GetUsersList;
using Gamax.Application.Profiles;
using Gamax.Domain.Entities;
using Gamax.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamax.UnitTest.Categories.Queries
{
    public class GetUserListQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly IMapper _mapper;

        public GetUserListQueryHandlerTests()
        {
            _mockUserRepository = RepositoryMocks.GetUserRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetUserListTest()
        {
            var handler = new GetUserListQueryHandler(_mapper, _mockUserRepository.Object);

            var result = await handler.Handle(new GetUserListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<UserListVm>>();
            result.Count.ShouldBe(3);
        }
    }
}
