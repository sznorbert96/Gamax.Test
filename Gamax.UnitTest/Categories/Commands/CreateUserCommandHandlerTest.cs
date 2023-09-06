using AutoMapper;
using Gamax.Application.Contracts.Persistence;
using Gamax.Application.Features.Users.Command.CreateUser;
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

namespace Gamax.UnitTest.Categories.Commands
{
    public class CreateUserCommandHandlerTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandlerTest()
        {
            _mockUserRepository = RepositoryMocks.GetUserRepository();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidUser_Added()
        {
            var handler = new CreateUserCommandHandler(_mapper, _mockUserRepository.Object);

            await handler.Handle(new CreateUserCommand() { BirthDate = DateTime.Parse("1992.12.01"), Email = "testemail@gmail.com", FirstName = "Test", LastName = "Test", Password = "Test" },
                CancellationToken.None);

            var allCategories = await _mockUserRepository.Object.ListAllAsync();
            allCategories.Count.ShouldBe(4);
        }
    }
}
